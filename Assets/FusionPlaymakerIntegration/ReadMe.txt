Integration with Photon Fusion for Playmaker Visual Scripting
-------------------------
Quick Start Guide
-------------------------
1. Create your Unity Project
2. Install Photon Fusion (https://doc.photonengine.com/fusion/current/getting-started/sdk-download)
3. Install Playmaker
4. Install this asset.
5. If you get errors regarding PlaymakerUtils, install the package at Assets/FusionPlaymakerIntegration/PlaymakerUtils
6. Check out the three Demo Scenes.

-------------------------
Creating Your First Scene
-------------------------
1. Create your Scene
2. Navigate to FusionPlaymakerIntegration>Prefabs
3. Drag ONLY the PlaymakerFusionNetworkRunner Prefab into the scene.
4. Begin creating your Connection logic using a Playmaker FSM. Use the Demo scenes as guides.

Release Notes:

2.4:
-Added 'FusionRPCTargetOthers'.
-Updated 'FusionSpawnNetworkObject' to set Rotation
-Fixed bug for Network Syncing string arrays

2.3.1:
-Bug Fix on FusionSpawnNetworkObject so you can mark as local player object.

2.3.0:
-Added New Action 'FusionIsLocalPlayerMasterClient'
-Added New Action 'FusionUnloadScene'
-Improved the 'FusionLoadScene' action

2.2.2: 
-Fixed Demo Scenes for Fusion 2
-Added PlaymakerUtils package so you don't have to get from Ecosystem

2.2.1: Bug Fixes from 2.2.0 for Fusion 2

2.2.0: Can Choose Region when Starting Session or Lobby

2.1.1
-Bug Fix related to spawning the RPC Handler on connecting to session.

2.1.0
-Used scripting symbols to not have to have seperate installation folders for FUSION 2 or FUSION 1. You should now be able to install without worrying about that.

2.0.0
-Converted to Work with Fusion 2. Make sure you uncheck 'Fusion 1' in this package if you want to use Fusion 2 (and vice versa if you want to use Fusion 1)

1.6.0
-Added 'FusionGetPlayerObject'
-Added 'FusionGetAllPlayersObject'

1.5.1
-Updated `FusionDespawnNetworkObject` action to catch if something is null or you don't have stateauthority.
-Updated RPC actions with a bool to allow you to not send RPC if NetworkObject is null.

1.5.0
-Added 'FusionSetSessionIsOpen' action.
-Added 'FusionSetSessionIsVisible' action.
-Added 'FusionUpdateSingleSessionCustomProperty' action.
-Added 'FusionSetSessionCustomProperties' action.
-Added 'FusionGetSingleSessionCustomProperty' action.
-Added `FusionGetScene` action.

1.4.0
-Updated 'FusionGetSessionInfo' to log a warning if not currently connected to a session.
-On 'Play' , Console will log an error if 'PlaymakerFusionSetupSyncVariables' has not been fully setup (or a prefab didn't save it)
-Every RPC action was updated with the option to target a specific Network Object.

1.3.2
-To help those migrating from older versions of this asset, I forced the PFNR to set the RpcHandler to null in awake.
-Added new action "FusionStartGameSimple" to make it easier to join random sessions.

1.3.1
-Fixed issue where on play you would frequently get this message "ArgumentException: An item with the same key has already been added. Key: [Player:0]"
-You no longer should put the PlaymakerFusionRPCHandler Prefab in the scene. It will get created automatically when needed
-Fixed issue where RPC's Targeted to a specific object wasn't working

1.3.0
-Updated 'FusionStartGame' action to support more options for matchmaking
-Fixed 'FusionGetSessionInfo' to support Custom Session Properties
-Added tooltip to 'FusionGetSessionInfo'
-Added 'FusionGetThisSessionInfo' action
-Added 'FusionSetSessionInfo' action

1.2.0
-Added 'ReleaseStateAuthority' Action
-Fixed error on bool in 'FusionObjectHasStateAuthority'

1.1.3
-Fixed a bug that made it impossible to use networksync variables

1.1.2
-Set PlaymakerFusionRPCHandler to DoNotDestroyOnLoad (but doesn't happen until NetworkRunner has connected)
-If RPCHandler variable not set on PlaymakerFusionNetworkRunner, it looks for it

1.1.1
-Added ability to get PlayerID from 'OnPlayerJoined' and 'OnPlayerLeft'
-Added 'FusionRpcPlayer'
-Added a bool to 'FusionSpawnNetworkObject' to set as local player object
-Minor Bug Fix

1.1.0
-The Demo Input Actions Were not In the Previous Versions
-Added a FAQ
-Fixed issue with 'HasInputAuthority' and 'HasStateAuthority' that would error if wasn't a networkobject.
-Fixed issue with 'FusionObjectWhoHasStateAuthority' that would cuase error if wasn't a networkobject.
-Added ability to start game in GameMode.Single so a player can play offline
-Added 'GetNetworkObjectId' action
-Added 'GetNetworkObjectComponent' action
-Added 'FusionRpcToNetworkObject' action
-Added 'RequestStateAuthority'

1.0.1
-Made changes to the Runner Shutdown action
-Made Changes to PlaymakerFusionNetworkRunner component

1.0.0 - Initial Release