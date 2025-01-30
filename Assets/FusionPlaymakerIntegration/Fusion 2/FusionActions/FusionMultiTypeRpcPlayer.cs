using Fusion;
using HutongGames.PlayMaker;
using UnityEngine;

namespace GooglyEyesGames.PlayMaker.Fusion
{

	[ActionCategory("Fusion")]
    [HutongGames.PlayMaker.Tooltip("This action is provided for convienience, but will send unnecessary bytes over the network. Still useful if you want to send 2 or more pieces of data with your RPC. Just keep in mind, you'll be wasting some bytes when you do so.")]
    public class FusionMultiTypeRpcPlayer : FsmStateAction
	{
        [RequiredField]
        [HutongGames.PlayMaker.Tooltip("The int representing the PlayerRef of the player you want to recieve the RPC.")]
        public FsmInt playerNumber;

        [RequiredField]
		[HutongGames.PlayMaker.Tooltip("The event you want to send.")]
		public FsmEvent remoteEvent;

        public FsmBool boolData;
        public FsmInt intData;
        public FsmFloat floatData;
        public FsmVector2 vector2Data;
        public FsmVector3 vector3Data;
        public FsmString stringData;
        public FsmRect rectData;
        public FsmQuaternion quatData;
        public FsmColor colorData;

		public override void OnEnter()
        {
            PlaymakerFusionNetworkRunner.PFNR.rpcHandler.TargetPlayer(playerNumber.Value, remoteEvent.Name, boolData.Value, intData.Value, floatData.Value, vector2Data.Value,vector3Data.Value, stringData.Value, rectData.Value, quatData.Value, colorData.Value);

            Finish();
		}


	}

}
