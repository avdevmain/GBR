using Fusion;
using HutongGames.PlayMaker;
using UnityEngine;

namespace GooglyEyesGames.PlayMaker.Fusion
{

	[ActionCategory("Fusion")]
    [HutongGames.PlayMaker.Tooltip("This action is provided for convienience, but will send unnecessary bytes over the network. Still useful if you want to send 2 or more pieces of data with your RPC. Just keep in mind, you'll be wasting some bytes when you do so.")]
    public class FusionMultiTypeRpc : FsmStateAction
	{
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

        [ActionSection("Optionally target a Network Object")]
        [UIHint(UIHint.Variable)]
        public FsmObject networkObjectTarget;
        public FsmBool doNothingIfNulll;

        public override void OnEnter()
        {
            if (networkObjectTarget.Value == null && doNothingIfNulll.Value == false)
            {
                PlaymakerFusionNetworkRunner.PFNR.rpcHandler.TargetAll(remoteEvent.Name, boolData.Value, intData.Value, floatData.Value, vector2Data.Value,
                                                                    vector3Data.Value, stringData.Value, rectData.Value, quatData.Value, colorData.Value);
            }
            else if(doNothingIfNulll.Value == false)
            {
                PlaymakerFusionNetworkRunner.PFNR.rpcHandler.TargetObject((NetworkObject)networkObjectTarget.Value, remoteEvent.Name, boolData.Value, intData.Value, floatData.Value, vector2Data.Value,
                                                                    vector3Data.Value, stringData.Value, rectData.Value, quatData.Value, colorData.Value);
            }
            

            Finish();
		}


	}

}
