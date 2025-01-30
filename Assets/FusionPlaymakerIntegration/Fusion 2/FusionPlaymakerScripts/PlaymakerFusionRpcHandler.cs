#if !FUSION2
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using HutongGames.PlayMaker;

namespace GooglyEyesGames.PlayMaker.Fusion
{
    public class PlaymakerFusionRpcHandler : NetworkBehaviour
    {

        private void Awake()
        {
            PlaymakerFusionNetworkRunner.PFNR.rpcHandler = this;
            DontDestroyOnLoad(this.gameObject);
        }
        #region Target Player
        public void TargetPlayer(int playerNumber, string eventName, bool boolData = false, int intData = -1, float floatData = -1,
                                Vector2 vector2Data = default(Vector2), Vector3 vector3Data = default(Vector3), string stringData = null,
                                Rect rectData = default(Rect), Quaternion quatData = default(Quaternion), Color colorData = default)
        {
            RPC_TargetPlayer(playerNumber, eventName, boolData, intData, floatData, vector2Data, vector3Data, stringData, rectData, quatData, colorData);
        }

        public void TargetPlayer(int playerNumber, string eventName)
        {
            RPC_TargetPlayer(playerNumber, eventName);
        }

        [Rpc]
        public void RPC_TargetPlayer([RpcTarget] PlayerRef player, string eventName)
        {
            PlayMakerFSM.BroadcastEvent(eventName);
        }

        [Rpc]
        public void RPC_TargetPlayer([RpcTarget] PlayerRef player, string eventName, bool boolData = false, int intData = -1, float floatData = -1,
                                Vector2 vector2Data = default(Vector2), Vector3 vector3Data = default(Vector3), string stringData = null,
                                Rect rectData = default(Rect), Quaternion quatData = default(Quaternion), Color colorData = default)
        {
            Fsm.EventData.BoolData = boolData;
            Fsm.EventData.IntData = intData;
            Fsm.EventData.FloatData = floatData;
            Fsm.EventData.Vector2Data = vector2Data;
            Fsm.EventData.Vector3Data = vector3Data;
            Fsm.EventData.StringData = stringData;
            Fsm.EventData.RectData = rectData;
            Fsm.EventData.QuaternionData = quatData;
            Fsm.EventData.ColorData = colorData;

            PlayMakerFSM.BroadcastEvent(eventName);
        }
        public void TargetPlayer(int playerNumber, string eventName, bool boolData)
        {
            RPC_TargetPlayer(playerNumber, eventName, boolData);
        }
        [Rpc]
        public void RPC_TargetPlayer([RpcTarget] PlayerRef player, string eventName, bool boolData)
        {
            Fsm.EventData.BoolData = boolData;
            PlayMakerFSM.BroadcastEvent(eventName);
        }

        public void TargetPlayer(int playerNumber, string eventName, int intData)
        {
            RPC_TargetPlayer(playerNumber, eventName, intData);
        }

        [Rpc]
        public void RPC_TargetPlayer([RpcTarget] PlayerRef player, string eventName, int intData)
        {
            Fsm.EventData.IntData = intData;
            PlayMakerFSM.BroadcastEvent(eventName);
        }
        public void TargetPlayer(int playerNumber, string eventName, float floatData)
        {
            RPC_TargetPlayer(playerNumber, eventName, floatData);
        }
        [Rpc]
        public void RPC_TargetPlayer([RpcTarget] PlayerRef player, string eventName, float floatData)
        {
            Fsm.EventData.FloatData = floatData;
            PlayMakerFSM.BroadcastEvent(eventName);
        }

        public void TargetPlayer(int playerNumber, string eventName, Vector2 vector2Data)
        {
            RPC_TargetPlayer(playerNumber, eventName, vector2Data);
        }
        [Rpc]
        public void RPC_TargetPlayer([RpcTarget] PlayerRef player, string eventName, Vector2 vector2Data)
        {
            Fsm.EventData.Vector2Data = vector2Data;
            PlayMakerFSM.BroadcastEvent(eventName);
        }

        public void TargetPlayer(int playerNumber, string eventName, Vector3 vector3Data)
        {
            RPC_TargetPlayer(playerNumber, eventName, vector3Data);
        }
        [Rpc]
        public void RPC_TargetPlayer([RpcTarget] PlayerRef player, string eventName, Vector3 vector3Data)
        {
            Fsm.EventData.Vector3Data = vector3Data;
            PlayMakerFSM.BroadcastEvent(eventName);
        }

        public void TargetPlayer(int playerNumber, string eventName, string stringData)
        {
            RPC_TargetPlayer(playerNumber, eventName, stringData);
        }
        [Rpc]
        public void RPC_TargetPlayer([RpcTarget] PlayerRef player, string eventName, string stringData)
        {
            Fsm.EventData.StringData = stringData;
            PlayMakerFSM.BroadcastEvent(eventName);
        }

        public void TargetPlayer(int playerNumber, string eventName, Rect rectData)
        {
            RPC_TargetPlayer(playerNumber, eventName, rectData);
        }
        [Rpc]
        public void RPC_TargetPlayer([RpcTarget] PlayerRef player, string eventName, Rect rectData)
        {
            Fsm.EventData.RectData = rectData;
            PlayMakerFSM.BroadcastEvent(eventName);
        }

        public void TargetPlayer(int playerNumber, string eventName, Quaternion quatData)
        {
            RPC_TargetPlayer(playerNumber, eventName, quatData);
        }
        [Rpc]
        public void RPC_TargetPlayer([RpcTarget] PlayerRef player, string eventName, Quaternion quatData)
        {
            Fsm.EventData.QuaternionData = quatData;
            PlayMakerFSM.BroadcastEvent(eventName);
        }

        public void TargetPlayer(int playerNumber, string eventName, Color colorData)
        {
            RPC_TargetPlayer(playerNumber, eventName, colorData);
        }
        [Rpc]
        public void RPC_TargetPlayer([RpcTarget] PlayerRef player, string eventName, Color colorData)
        {
            Fsm.EventData.ColorData = colorData;
            PlayMakerFSM.BroadcastEvent(eventName);
        }
        #endregion

        #region TargetAll
        public void TargetAll(string eventName, bool boolData = false, int intData = -1, float floatData = -1,
                                Vector2 vector2Data = default(Vector2), Vector3 vector3Data = default(Vector3), string stringData = null,
                                Rect rectData = default(Rect), Quaternion quatData = default(Quaternion), Color colorData = default)
        {
            RPC_TargetAll(eventName, boolData, intData, floatData, vector2Data, vector3Data, stringData, rectData, quatData, colorData);
        }
        [Rpc]
        public void RPC_TargetAll(string eventName, bool boolData = false, int intData = -1, float floatData = -1,
                                Vector2 vector2Data = default(Vector2), Vector3 vector3Data = default(Vector3), string stringData = null,
                                Rect rectData = default(Rect), Quaternion quatData = default(Quaternion), Color colorData = default)
        {
            Fsm.EventData.BoolData = boolData;
            Fsm.EventData.IntData = intData;
            Fsm.EventData.FloatData = floatData;
            Fsm.EventData.Vector2Data = vector2Data;
            Fsm.EventData.Vector3Data = vector3Data;
            Fsm.EventData.StringData = stringData;
            Fsm.EventData.RectData = rectData;
            Fsm.EventData.QuaternionData = quatData;
            Fsm.EventData.ColorData = colorData;

            PlayMakerFSM.BroadcastEvent(eventName);
        }

        public void TargetAll(string eventName)
        {
            RPC_TargetAll(eventName);
        }

        [Rpc]
        public void RPC_TargetAll(string eventName)
        {
            PlayMakerFSM.BroadcastEvent(eventName);
        }
        public void TargetAll(string eventName, bool boolData)
        {
            RPC_TargetAll(eventName, boolData);
        }
        [Rpc]
        public void RPC_TargetAll(string eventName, bool boolData)
        {
            Fsm.EventData.BoolData = boolData;
            PlayMakerFSM.BroadcastEvent(eventName);
        }

        public void TargetAll(string eventName, int intData)
        {
            RPC_TargetAll(eventName, intData);
        }

        [Rpc]
        public void RPC_TargetAll(string eventName, int intData)
        {
            Fsm.EventData.IntData = intData;
            PlayMakerFSM.BroadcastEvent(eventName);
        }

        public void TargetAll(string eventName, float floatData)
        {
            RPC_TargetAll(eventName, floatData);
        }
        [Rpc]
        public void RPC_TargetAll(string eventName, float floatData)
        {
            Fsm.EventData.FloatData = floatData;
            PlayMakerFSM.BroadcastEvent(eventName);
        }

        public void TargetAll(string eventName, Vector2 vector2Data)
        {
            RPC_TargetAll(eventName, vector2Data);
        }
        [Rpc]
        public void RPC_TargetAll(string eventName, Vector2 vector2Data)
        {
            Fsm.EventData.Vector2Data = vector2Data;
            PlayMakerFSM.BroadcastEvent(eventName);
        }

        public void TargetAll(string eventName, Vector3 vector3Data)
        {
            RPC_TargetAll(eventName, vector3Data);
        }
        [Rpc]
        public void RPC_TargetAll(string eventName, Vector3 vector3Data)
        {
            Fsm.EventData.Vector3Data = vector3Data;
            PlayMakerFSM.BroadcastEvent(eventName);
        }

        public void TargetAll(string eventName, string stringData)
        {
            RPC_TargetAll(eventName, stringData);
        }
        [Rpc]
        public void RPC_TargetAll(string eventName, string stringData)
        {
            Fsm.EventData.StringData = stringData;
            PlayMakerFSM.BroadcastEvent(eventName);
        }

        public void TargetAll(string eventName, Rect rectData)
        {
            RPC_TargetAll(eventName, rectData);
        }
        [Rpc]
        public void RPC_TargetAll(string eventName, Rect rectData)
        {
            Fsm.EventData.RectData = rectData;
            PlayMakerFSM.BroadcastEvent(eventName);
        }

        public void TargetAll(string eventName, Quaternion quatData)
        {
            RPC_TargetAll(eventName, quatData);
        }
        [Rpc]
        public void RPC_TargetAll(string eventName, Quaternion quatData)
        {
            Fsm.EventData.QuaternionData = quatData;
            PlayMakerFSM.BroadcastEvent(eventName);
        }

        public void TargetAll(string eventName, Color colorData)
        {
            RPC_TargetObject(eventName, colorData);
        }
        [Rpc]
        public void RPC_TargetObject(string eventName, Color colorData)
        {
            Fsm.EventData.ColorData = colorData;
            PlayMakerFSM.BroadcastEvent(eventName);
        }
        #endregion

        #region Target Object

        public void TargetObject(NetworkObject target, string eventName)
        {
            RPC_TargetObject(target, eventName);
        }

        [Rpc]
        public void RPC_TargetObject(NetworkObject target, string eventName)
        {
            PlayMakerUtils.SendEventToGameObject(GetComponent<PlayMakerFSM>(), target.gameObject, eventName);
        }

        public void TargetObject(NetworkObject target, string eventName, bool boolData = false, int intData = -1, float floatData = -1,
                                Vector2 vector2Data = default(Vector2), Vector3 vector3Data = default(Vector3), string stringData = null,
                                Rect rectData = default(Rect), Quaternion quatData = default(Quaternion), Color colorData = default)
        {
            RPC_TargetObject(target, eventName, boolData, intData, floatData, vector2Data, vector3Data, stringData, rectData, quatData, colorData);
        }
        [Rpc]
        public void RPC_TargetObject(NetworkObject target, string eventName, bool boolData = false, int intData = -1, float floatData = -1,
                                Vector2 vector2Data = default(Vector2), Vector3 vector3Data = default(Vector3), string stringData = null,
                                Rect rectData = default(Rect), Quaternion quatData = default(Quaternion), Color colorData = default)
        {
            Fsm.EventData.BoolData = boolData;
            Fsm.EventData.IntData = intData;
            Fsm.EventData.FloatData = floatData;
            Fsm.EventData.Vector2Data = vector2Data;
            Fsm.EventData.Vector3Data = vector3Data;
            Fsm.EventData.StringData = stringData;
            Fsm.EventData.RectData = rectData;
            Fsm.EventData.QuaternionData = quatData;
            Fsm.EventData.ColorData = colorData;

            PlayMakerUtils.SendEventToGameObject(GetComponent<PlayMakerFSM>(), target.gameObject, eventName);
        }

        public void TargetObject(NetworkObject target, string eventName, bool boolData)
        {
            RPC_TargetObject(target, eventName, boolData);
        }
        [Rpc]
        public void RPC_TargetObject(NetworkObject target, string eventName, bool boolData)
        {
            Fsm.EventData.BoolData = boolData;
            PlayMakerUtils.SendEventToGameObject(GetComponent<PlayMakerFSM>(), target.gameObject, eventName);
        }

        public void TargetObject(NetworkObject target, string eventName, int intData)
        {
            RPC_TargetObject(target, eventName, intData);
        }

        [Rpc]
        public void RPC_TargetObject(NetworkObject target, string eventName, int intData)
        {
            Fsm.EventData.IntData = intData;
            PlayMakerUtils.SendEventToGameObject(GetComponent<PlayMakerFSM>(), target.gameObject, eventName);
        }

        public void TargetObject(NetworkObject target, string eventName, float floatData)
        {
            RPC_TargetObject(target, eventName, floatData);
        }
        [Rpc]
        public void RPC_TargetObject(NetworkObject target, string eventName, float floatData)
        {
            Fsm.EventData.FloatData = floatData;
            PlayMakerUtils.SendEventToGameObject(GetComponent<PlayMakerFSM>(), target.gameObject, eventName);
        }

        public void TargetObject(NetworkObject target, string eventName, Vector2 vector2Data)
        {
            RPC_TargetObject(target, eventName, vector2Data);
        }
        [Rpc]
        public void RPC_TargetObject(NetworkObject target, string eventName, Vector2 vector2Data)
        {
            Fsm.EventData.Vector2Data = vector2Data;
            PlayMakerUtils.SendEventToGameObject(GetComponent<PlayMakerFSM>(), target.gameObject, eventName);
        }

        public void TargetObject(NetworkObject target, string eventName, Vector3 vector3Data)
        {
            RPC_TargetObject(target, eventName, vector3Data);
        }
        [Rpc]
        public void RPC_TargetObject(NetworkObject target, string eventName, Vector3 vector3Data)
        {
            Fsm.EventData.Vector3Data = vector3Data;
            PlayMakerUtils.SendEventToGameObject(GetComponent<PlayMakerFSM>(), target.gameObject, eventName);
        }

        public void TargetObject(NetworkObject target, string eventName, string stringData)
        {
            RPC_TargetObject(target, eventName, stringData);
        }
        [Rpc]
        public void RPC_TargetObject(NetworkObject target, string eventName, string stringData)
        {
            Fsm.EventData.StringData = stringData;
            PlayMakerUtils.SendEventToGameObject(GetComponent<PlayMakerFSM>(), target.gameObject, eventName);
        }

        public void TargetObject(NetworkObject target, string eventName, Rect rectData)
        {
            RPC_TargetObject(target, eventName, rectData);
        }
        [Rpc]
        public void RPC_TargetObject(NetworkObject target, string eventName, Rect rectData)
        {
            Fsm.EventData.RectData = rectData;
            PlayMakerUtils.SendEventToGameObject(GetComponent<PlayMakerFSM>(), target.gameObject, eventName);
        }

        public void TargetObject(NetworkObject target, string eventName, Quaternion quatData)
        {
            RPC_TargetObject(target, eventName, quatData);
        }
        [Rpc]
        public void RPC_TargetObject(NetworkObject target, string eventName, Quaternion quatData)
        {
            Fsm.EventData.QuaternionData = quatData;
            PlayMakerUtils.SendEventToGameObject(GetComponent<PlayMakerFSM>(), target.gameObject, eventName);
        }

        public void TargetObject(NetworkObject target, string eventName, Color colorData)
        {
            RPC_TargetObject(target, eventName, colorData);
        }
        [Rpc]
        public void RPC_TargetObject(NetworkObject target, string eventName, Color colorData)
        {
            Fsm.EventData.ColorData = colorData;
            PlayMakerUtils.SendEventToGameObject(GetComponent<PlayMakerFSM>(), target.gameObject, eventName);
        }

        #endregion
    }
}
#endif

#if FUSION2
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using HutongGames.PlayMaker;

namespace GooglyEyesGames.PlayMaker.Fusion
{
    public class PlaymakerFusionRpcHandler : NetworkBehaviour
    {

        private void Awake()
        {
            PlaymakerFusionNetworkRunner.PFNR.rpcHandler = this;
            DontDestroyOnLoad(this.gameObject);
        }
        #region Target Player
        public void TargetPlayer(int playerNumber, string eventName, bool boolData = false, int intData = -1, float floatData = -1,
                                Vector2 vector2Data = default(Vector2), Vector3 vector3Data = default(Vector3), string stringData = null,
                                Rect rectData = default(Rect), Quaternion quatData = default(Quaternion), Color colorData = default)
        {
            RPC_TargetPlayer(PlayerRef.FromIndex(playerNumber), eventName, boolData, intData, floatData, vector2Data, vector3Data, stringData, rectData, quatData, colorData);
        }

        public void TargetPlayer(int playerNumber, string eventName)
        {
            RPC_TargetPlayer(PlayerRef.FromIndex(playerNumber), eventName);
        }

        [Rpc]
        public void RPC_TargetPlayer([RpcTarget] PlayerRef player, string eventName)
        {
            PlayMakerFSM.BroadcastEvent(eventName);
        }

        [Rpc]
        public void RPC_TargetPlayer([RpcTarget] PlayerRef player, string eventName, bool boolData = false, int intData = -1, float floatData = -1,
                                Vector2 vector2Data = default(Vector2), Vector3 vector3Data = default(Vector3), string stringData = null,
                                Rect rectData = default(Rect), Quaternion quatData = default(Quaternion), Color colorData = default)
        {
            Fsm.EventData.BoolData = boolData;
            Fsm.EventData.IntData = intData;
            Fsm.EventData.FloatData = floatData;
            Fsm.EventData.Vector2Data = vector2Data;
            Fsm.EventData.Vector3Data = vector3Data;
            Fsm.EventData.StringData = stringData;
            Fsm.EventData.RectData = rectData;
            Fsm.EventData.QuaternionData = quatData;
            Fsm.EventData.ColorData = colorData;

            PlayMakerFSM.BroadcastEvent(eventName);
        }
        public void TargetPlayer(int playerNumber, string eventName, bool boolData)
        {
            RPC_TargetPlayer(PlayerRef.FromIndex(playerNumber), eventName, boolData);
        }
        [Rpc]
        public void RPC_TargetPlayer([RpcTarget] PlayerRef player, string eventName, bool boolData)
        {
            Fsm.EventData.BoolData = boolData;
            PlayMakerFSM.BroadcastEvent(eventName);
        }

        public void TargetPlayer(int playerNumber, string eventName, int intData)
        {
            RPC_TargetPlayer(PlayerRef.FromIndex(playerNumber), eventName, intData);
        }

        [Rpc]
        public void RPC_TargetPlayer([RpcTarget] PlayerRef player, string eventName, int intData)
        {
            Fsm.EventData.IntData = intData;
            PlayMakerFSM.BroadcastEvent(eventName);
        }
        public void TargetPlayer(int playerNumber, string eventName, float floatData)
        {
            RPC_TargetPlayer(PlayerRef.FromIndex(playerNumber), eventName, floatData);
        }
        [Rpc]
        public void RPC_TargetPlayer([RpcTarget] PlayerRef player, string eventName, float floatData)
        {
            Fsm.EventData.FloatData = floatData;
            PlayMakerFSM.BroadcastEvent(eventName);
        }

        public void TargetPlayer(int playerNumber, string eventName, Vector2 vector2Data)
        {
            RPC_TargetPlayer(PlayerRef.FromIndex(playerNumber), eventName, vector2Data);
        }
        [Rpc]
        public void RPC_TargetPlayer([RpcTarget] PlayerRef player, string eventName, Vector2 vector2Data)
        {
            Fsm.EventData.Vector2Data = vector2Data;
            PlayMakerFSM.BroadcastEvent(eventName);
        }

        public void TargetPlayer(int playerNumber, string eventName, Vector3 vector3Data)
        {
            RPC_TargetPlayer(PlayerRef.FromIndex(playerNumber), eventName, vector3Data);
        }
        [Rpc]
        public void RPC_TargetPlayer([RpcTarget] PlayerRef player, string eventName, Vector3 vector3Data)
        {
            Fsm.EventData.Vector3Data = vector3Data;
            PlayMakerFSM.BroadcastEvent(eventName);
        }

        public void TargetPlayer(int playerNumber, string eventName, string stringData)
        {
            RPC_TargetPlayer(PlayerRef.FromIndex(playerNumber), eventName, stringData);
        }
        [Rpc]
        public void RPC_TargetPlayer([RpcTarget] PlayerRef player, string eventName, string stringData)
        {
            Fsm.EventData.StringData = stringData;
            PlayMakerFSM.BroadcastEvent(eventName);
        }

        public void TargetPlayer(int playerNumber, string eventName, Rect rectData)
        {
            RPC_TargetPlayer(PlayerRef.FromIndex(playerNumber), eventName, rectData);
        }
        [Rpc]
        public void RPC_TargetPlayer([RpcTarget] PlayerRef player, string eventName, Rect rectData)
        {
            Fsm.EventData.RectData = rectData;
            PlayMakerFSM.BroadcastEvent(eventName);
        }

        public void TargetPlayer(int playerNumber, string eventName, Quaternion quatData)
        {
            RPC_TargetPlayer(PlayerRef.FromIndex(playerNumber), eventName, quatData);
        }
        [Rpc]
        public void RPC_TargetPlayer([RpcTarget] PlayerRef player, string eventName, Quaternion quatData)
        {
            Fsm.EventData.QuaternionData = quatData;
            PlayMakerFSM.BroadcastEvent(eventName);
        }

        public void TargetPlayer(int playerNumber, string eventName, Color colorData)
        {
            RPC_TargetPlayer(PlayerRef.FromIndex(playerNumber), eventName, colorData);
        }
        [Rpc]
        public void RPC_TargetPlayer([RpcTarget] PlayerRef player, string eventName, Color colorData)
        {
            Fsm.EventData.ColorData = colorData;
            PlayMakerFSM.BroadcastEvent(eventName);
        }
        #endregion

        #region TargetAll
        public void TargetAll(string eventName, bool boolData = false, int intData = -1, float floatData = -1,
                                Vector2 vector2Data = default(Vector2), Vector3 vector3Data = default(Vector3), string stringData = null,
                                Rect rectData = default(Rect), Quaternion quatData = default(Quaternion), Color colorData = default)
        {
            RPC_TargetAll(eventName, boolData, intData, floatData, vector2Data, vector3Data, stringData, rectData, quatData, colorData);
        }
        [Rpc]
        public void RPC_TargetAll(string eventName, bool boolData = false, int intData = -1, float floatData = -1,
                                Vector2 vector2Data = default(Vector2), Vector3 vector3Data = default(Vector3), string stringData = null,
                                Rect rectData = default(Rect), Quaternion quatData = default(Quaternion), Color colorData = default)
        {
            Fsm.EventData.BoolData = boolData;
            Fsm.EventData.IntData = intData;
            Fsm.EventData.FloatData = floatData;
            Fsm.EventData.Vector2Data = vector2Data;
            Fsm.EventData.Vector3Data = vector3Data;
            Fsm.EventData.StringData = stringData;
            Fsm.EventData.RectData = rectData;
            Fsm.EventData.QuaternionData = quatData;
            Fsm.EventData.ColorData = colorData;

            PlayMakerFSM.BroadcastEvent(eventName);
        }

        public void TargetAll(string eventName)
        {
            RPC_TargetAll(eventName);
        }

        [Rpc]
        public void RPC_TargetAll(string eventName)
        {
            PlayMakerFSM.BroadcastEvent(eventName);
        }
        public void TargetAll(string eventName, bool boolData)
        {
            RPC_TargetAll(eventName, boolData);
        }
        [Rpc]
        public void RPC_TargetAll(string eventName, bool boolData)
        {
            Fsm.EventData.BoolData = boolData;
            PlayMakerFSM.BroadcastEvent(eventName);
        }

        public void TargetAll(string eventName, int intData)
        {
            RPC_TargetAll(eventName, intData);
        }

        [Rpc]
        public void RPC_TargetAll(string eventName, int intData)
        {
            Fsm.EventData.IntData = intData;
            PlayMakerFSM.BroadcastEvent(eventName);
        }

        public void TargetAll(string eventName, float floatData)
        {
            RPC_TargetAll(eventName, floatData);
        }
        [Rpc]
        public void RPC_TargetAll(string eventName, float floatData)
        {
            Fsm.EventData.FloatData = floatData;
            PlayMakerFSM.BroadcastEvent(eventName);
        }

        public void TargetAll(string eventName, Vector2 vector2Data)
        {
            RPC_TargetAll(eventName, vector2Data);
        }
        [Rpc]
        public void RPC_TargetAll(string eventName, Vector2 vector2Data)
        {
            Fsm.EventData.Vector2Data = vector2Data;
            PlayMakerFSM.BroadcastEvent(eventName);
        }

        public void TargetAll(string eventName, Vector3 vector3Data)
        {
            RPC_TargetAll(eventName, vector3Data);
        }
        [Rpc]
        public void RPC_TargetAll(string eventName, Vector3 vector3Data)
        {
            Fsm.EventData.Vector3Data = vector3Data;
            PlayMakerFSM.BroadcastEvent(eventName);
        }

        public void TargetAll(string eventName, string stringData)
        {
            RPC_TargetAll(eventName, stringData);
        }
        [Rpc]
        public void RPC_TargetAll(string eventName, string stringData)
        {
            Fsm.EventData.StringData = stringData;
            PlayMakerFSM.BroadcastEvent(eventName);
        }

        public void TargetAll(string eventName, Rect rectData)
        {
            RPC_TargetAll(eventName, rectData);
        }
        [Rpc]
        public void RPC_TargetAll(string eventName, Rect rectData)
        {
            Fsm.EventData.RectData = rectData;
            PlayMakerFSM.BroadcastEvent(eventName);
        }

        public void TargetAll(string eventName, Quaternion quatData)
        {
            RPC_TargetAll(eventName, quatData);
        }
        [Rpc]
        public void RPC_TargetAll(string eventName, Quaternion quatData)
        {
            Fsm.EventData.QuaternionData = quatData;
            PlayMakerFSM.BroadcastEvent(eventName);
        }

        public void TargetAll(string eventName, Color colorData)
        {
            RPC_TargetObject(eventName, colorData);
        }
        [Rpc]
        public void RPC_TargetObject(string eventName, Color colorData)
        {
            Fsm.EventData.ColorData = colorData;
            PlayMakerFSM.BroadcastEvent(eventName);
        }
        #endregion

        #region Target Object

        public void TargetObject(NetworkObject target, string eventName)
        {
            RPC_TargetObject(target, eventName);
        }

        [Rpc]
        public void RPC_TargetObject(NetworkObject target, string eventName)
        {
            PlayMakerUtils.SendEventToGameObject(GetComponent<PlayMakerFSM>(), target.gameObject, eventName);
        }

        public void TargetObject(NetworkObject target, string eventName, bool boolData = false, int intData = -1, float floatData = -1,
                                Vector2 vector2Data = default(Vector2), Vector3 vector3Data = default(Vector3), string stringData = null,
                                Rect rectData = default(Rect), Quaternion quatData = default(Quaternion), Color colorData = default)
        {
            RPC_TargetObject(target, eventName, boolData, intData, floatData, vector2Data, vector3Data, stringData, rectData, quatData, colorData);
        }
        [Rpc]
        public void RPC_TargetObject(NetworkObject target, string eventName, bool boolData = false, int intData = -1, float floatData = -1,
                                Vector2 vector2Data = default(Vector2), Vector3 vector3Data = default(Vector3), string stringData = null,
                                Rect rectData = default(Rect), Quaternion quatData = default(Quaternion), Color colorData = default)
        {
            Fsm.EventData.BoolData = boolData;
            Fsm.EventData.IntData = intData;
            Fsm.EventData.FloatData = floatData;
            Fsm.EventData.Vector2Data = vector2Data;
            Fsm.EventData.Vector3Data = vector3Data;
            Fsm.EventData.StringData = stringData;
            Fsm.EventData.RectData = rectData;
            Fsm.EventData.QuaternionData = quatData;
            Fsm.EventData.ColorData = colorData;

            PlayMakerUtils.SendEventToGameObject(GetComponent<PlayMakerFSM>(), target.gameObject, eventName);
        }

        public void TargetObject(NetworkObject target, string eventName, bool boolData)
        {
            RPC_TargetObject(target, eventName, boolData);
        }
        [Rpc]
        public void RPC_TargetObject(NetworkObject target, string eventName, bool boolData)
        {
            Fsm.EventData.BoolData = boolData;
            PlayMakerUtils.SendEventToGameObject(GetComponent<PlayMakerFSM>(), target.gameObject, eventName);
        }

        public void TargetObject(NetworkObject target, string eventName, int intData)
        {
            RPC_TargetObject(target, eventName, intData);
        }

        [Rpc]
        public void RPC_TargetObject(NetworkObject target, string eventName, int intData)
        {
            Fsm.EventData.IntData = intData;
            PlayMakerUtils.SendEventToGameObject(GetComponent<PlayMakerFSM>(), target.gameObject, eventName);
        }

        public void TargetObject(NetworkObject target, string eventName, float floatData)
        {
            RPC_TargetObject(target, eventName, floatData);
        }
        [Rpc]
        public void RPC_TargetObject(NetworkObject target, string eventName, float floatData)
        {
            Fsm.EventData.FloatData = floatData;
            PlayMakerUtils.SendEventToGameObject(GetComponent<PlayMakerFSM>(), target.gameObject, eventName);
        }

        public void TargetObject(NetworkObject target, string eventName, Vector2 vector2Data)
        {
            RPC_TargetObject(target, eventName, vector2Data);
        }
        [Rpc]
        public void RPC_TargetObject(NetworkObject target, string eventName, Vector2 vector2Data)
        {
            Fsm.EventData.Vector2Data = vector2Data;
            PlayMakerUtils.SendEventToGameObject(GetComponent<PlayMakerFSM>(), target.gameObject, eventName);
        }

        public void TargetObject(NetworkObject target, string eventName, Vector3 vector3Data)
        {
            RPC_TargetObject(target, eventName, vector3Data);
        }
        [Rpc]
        public void RPC_TargetObject(NetworkObject target, string eventName, Vector3 vector3Data)
        {
            Fsm.EventData.Vector3Data = vector3Data;
            PlayMakerUtils.SendEventToGameObject(GetComponent<PlayMakerFSM>(), target.gameObject, eventName);
        }

        public void TargetObject(NetworkObject target, string eventName, string stringData)
        {
            RPC_TargetObject(target, eventName, stringData);
        }
        [Rpc]
        public void RPC_TargetObject(NetworkObject target, string eventName, string stringData)
        {
            Fsm.EventData.StringData = stringData;
            PlayMakerUtils.SendEventToGameObject(GetComponent<PlayMakerFSM>(), target.gameObject, eventName);
        }

        public void TargetObject(NetworkObject target, string eventName, Rect rectData)
        {
            RPC_TargetObject(target, eventName, rectData);
        }
        [Rpc]
        public void RPC_TargetObject(NetworkObject target, string eventName, Rect rectData)
        {
            Fsm.EventData.RectData = rectData;
            PlayMakerUtils.SendEventToGameObject(GetComponent<PlayMakerFSM>(), target.gameObject, eventName);
        }

        public void TargetObject(NetworkObject target, string eventName, Quaternion quatData)
        {
            RPC_TargetObject(target, eventName, quatData);
        }
        [Rpc]
        public void RPC_TargetObject(NetworkObject target, string eventName, Quaternion quatData)
        {
            Fsm.EventData.QuaternionData = quatData;
            PlayMakerUtils.SendEventToGameObject(GetComponent<PlayMakerFSM>(), target.gameObject, eventName);
        }

        public void TargetObject(NetworkObject target, string eventName, Color colorData)
        {
            RPC_TargetObject(target, eventName, colorData);
        }
        [Rpc]
        public void RPC_TargetObject(NetworkObject target, string eventName, Color colorData)
        {
            Fsm.EventData.ColorData = colorData;
            PlayMakerUtils.SendEventToGameObject(GetComponent<PlayMakerFSM>(), target.gameObject, eventName);
        }

        #endregion

        #region Target Others
        public void TargetOthers(string eventName)
        {
            RPC_TargetOthers(eventName);
        }

        [Rpc(RpcSources.StateAuthority, RpcTargets.Proxies)]
        public void RPC_TargetOthers(string eventName)
        {
            PlayMakerFSM.BroadcastEvent(eventName);
        }

        #endregion
    }
}

#endif
