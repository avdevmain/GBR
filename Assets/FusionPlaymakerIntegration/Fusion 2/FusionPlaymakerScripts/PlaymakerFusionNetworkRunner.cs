using Fusion;
using Fusion.Photon.Realtime;
using Fusion.Sockets;
using HutongGames.PlayMaker;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GooglyEyesGames.PlayMaker.Fusion
{
    public class PlaymakerFusionNetworkRunner : MonoBehaviour, INetworkRunnerCallbacks
    {
        public static PlaymakerFusionNetworkRunner PFNR;

        public NetworkRunner _runner;
        //public Dictionary<PlayerRef, NetworkObject> _spawnedCharacters = new Dictionary<PlayerRef, NetworkObject>();
        public PlayerRef playerRef;

        private INetworkSceneManager sceneManager;

        public NetworkObject rpcHandlerPrefab;
        [HideInInspector] public PlaymakerFusionRpcHandler rpcHandler;

        public List<SessionInfo> sessions;
        public void Awake()
        {
            rpcHandler = null;

            if (PFNR != null)
            {
                GameObject.Destroy(PFNR);
            }
            else
            {
                PFNR = this;
            }



        }

        private AppSettings BuildCustomAppSetting(string region)
        {
#if FUSION2
            var appSettings = PhotonAppSettings.Global.AppSettings.GetCopy();
#else
            var appSettings = PhotonAppSettings.Instance.AppSettings.GetCopy();
#endif

            //appSettings.UseNameServer = true;
            //appSettings.AppVersion = appVersion;

            /*if (string.IsNullOrEmpty(customAppID) == false)
            {
                appSettings.AppIdFusion = customAppID;
            }*/

            if (string.IsNullOrEmpty(region) == false)
            {
                appSettings.FixedRegion = region.ToLower();
            }

            // If the Region is set to China (CN),
            // the Name Server will be automatically changed to the right one
            // appSettings.Server = "ns.photonengine.cn";

            return appSettings;
        }
        public async void StartGame(string _sessionName, bool isVisible, string region = null, Dictionary<string, SessionProperty> sessionProperties = null, string lobbyName = null, int playerCount = -1)
        {
            if (_runner == null)
            {
                _runner = gameObject.AddComponent<NetworkRunner>();
            }

            var appSettings = BuildCustomAppSetting(region);

            // Create the scene manager if it does not exist
            if (sceneManager == null) sceneManager = gameObject.AddComponent<NetworkSceneManagerDefault>();
            // Start or join (depends on gamemode) a session with a specific name
            var args = new StartGameArgs()
            {
                GameMode = GameMode.Shared,
                SessionName = _sessionName,
                SceneManager = sceneManager,
                IsVisible = isVisible,
#if FUSION2
                CustomPhotonAppSettings = (FusionAppSettings)appSettings
#else
                CustomPhotonAppSettings = appSettings
#endif
            };

            if (sessionProperties != null)
            {
                args.SessionProperties = sessionProperties;
            }

            if (lobbyName != null)
            {
                args.CustomLobbyName = lobbyName;
            }

            if (playerCount != -1)
            {
                args.PlayerCount = playerCount;
            }

            await _runner.StartGame(args);
        }

        public async void StartGameSingle(string _sessionName, bool isVisible)
        {
            if (_runner == null)
            {
                _runner = gameObject.AddComponent<NetworkRunner>();
            }
            // Create the scene manager if it does not exist
            if (sceneManager == null) sceneManager = gameObject.AddComponent<NetworkSceneManagerDefault>();
            // Start or join (depends on gamemode) a session with a specific name
            var args = new StartGameArgs()
            {
                GameMode = GameMode.Single,
                SessionName = _sessionName,
#if !FUSION2
                Scene = SceneManager.GetActiveScene().buildIndex,
#endif
                SceneManager = sceneManager,
                IsVisible = isVisible
            };
            await _runner.StartGame(args);
        }

        public void ConnectToLobby(string lobbyName, string region = null)
        {
            var appSettings = BuildCustomAppSetting(region);

            if (_runner == null)
            {
                _runner = gameObject.AddComponent<NetworkRunner>();
            }
#if !FUSION2
            _runner.JoinSessionLobby(SessionLobby.Shared, lobbyName, null, appSettings);
#else
            _runner.JoinSessionLobby(SessionLobby.Shared, lobbyName, null, (FusionAppSettings)appSettings);
#endif
        }



        #region INetworkRunnerCallbacks

        public void OnConnectedToServer(NetworkRunner runner)
        {
            PlayMakerFSM.BroadcastEvent("Fusion / OnConnectedToServer");
            if (rpcHandler == null && runner.IsSharedModeMasterClient)
            {
                rpcHandler = _runner.Spawn(rpcHandlerPrefab).GetComponent<PlaymakerFusionRpcHandler>();
            }
        }


        public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
        {
            PlayMakerFSM.BroadcastEvent("Fusion / OnConnectFailed");
        }

        public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
        {
            PlayMakerFSM.BroadcastEvent("Fusion / OnConnectRequest");
        }

        public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
        {
            PlayMakerFSM.BroadcastEvent("Fusion / OnCustomAuthenticationResponse");
        }

        public void OnDisconnectedFromServer(NetworkRunner runner)
        {
            PlayMakerFSM.BroadcastEvent("Fusion / OnDisconnectedFromServer");
        }

        public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
        {
            PlayMakerFSM.BroadcastEvent("Fusion / OnHostMigration");
        }

        public void OnInput(NetworkRunner runner, NetworkInput input)
        {
            // Maybe we need to utilize this somehow.
            // this sets the NetworkInput struct. It doesn't actually move the player or anything
            // We can use our custom Editor window to auto-add the lines of code we need here for all our input types
            // https://doc.photonengine.com/en-us/fusion/current/fusion-100/fusion-102#applying_input
            // https://doc.photonengine.com/en-us/fusion/current/manual/network-input#unity_new_input_system
        }

        public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
        {
            PlayMakerFSM.BroadcastEvent("Fusion / OnInputMissing");
        }

        public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
        {
            playerRef = player;
            Fsm.EventData.IntData = player.PlayerId;
            PlayMakerFSM.BroadcastEvent("Fusion / OnPlayerJoined");
        }

        public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
        {
            // Find and remove the players avatar
            /*if (_spawnedCharacters.TryGetValue(player, out NetworkObject networkObject))
            {
                runner.Despawn(networkObject);
                _spawnedCharacters.Remove(player);
            }*/
            playerRef = player;
            Fsm.EventData.IntData = player.PlayerId;
            PlayMakerFSM.BroadcastEvent("Fusion / OnPlayerLeft");
        }

        public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data)
        {
            PlayMakerFSM.BroadcastEvent("Fusion / OnReliableDataReceived");
        }

        public void OnSceneLoadDone(NetworkRunner runner)
        {
            PlayMakerFSM.BroadcastEvent("Fusion / OnSceneLoadDone");
        }

        public void OnSceneLoadStart(NetworkRunner runner)
        {
            PlayMakerFSM.BroadcastEvent("Fusion / OnSceneLoadStart");
        }

        public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
        {
            sessions = sessionList;
            Debug.Log(sessionList.Count + " active sessions.");
            PlayMakerFSM.BroadcastEvent("Fusion / OnSessionListUpdated");
        }

        public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
        {
            Destroy(_runner);
            StartCoroutine(SendPlayMakerShutDownEvent());
        }

        private IEnumerator SendPlayMakerShutDownEvent()
        {
            yield return new WaitForEndOfFrame();
            PlayMakerFSM.BroadcastEvent("Fusion / OnShutdown");
        }

        public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
        {
            PlayMakerFSM.BroadcastEvent("Fusion / OnSimulationMessage");
        }

#if FUSION2
        public void OnObjectExitAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
        {
            PlayMakerFSM.BroadcastEvent("Fusion / OnObjectExitAOI");
        }

        public void OnObjectEnterAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
        {
            PlayMakerFSM.BroadcastEvent("Fusion / OnObjectEnterAOI");
        }

        public void OnDisconnectedFromServer(NetworkRunner runner, NetDisconnectReason reason)
        {
            PlayMakerFSM.BroadcastEvent("Fusion / OnDisconnectedFromServer");
        }

        public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ReliableKey key, ArraySegment<byte> data)
        {
            PlayMakerFSM.BroadcastEvent("Fusion / OnReliableDataReceived");
        }

        public void OnReliableDataProgress(NetworkRunner runner, PlayerRef player, ReliableKey key, float progress)
        {
            PlayMakerFSM.BroadcastEvent("Fusion / OnReliableDataProgress");
        }

#endif

        #endregion
    }


}