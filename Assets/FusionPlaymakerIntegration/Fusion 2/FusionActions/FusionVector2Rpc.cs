using Fusion;
using HutongGames.PlayMaker;
using UnityEngine;

namespace GooglyEyesGames.PlayMaker.Fusion
{

	[ActionCategory("Fusion")]
	public class FusionVector2Rpc : FsmStateAction
	{
		[RequiredField]
		[HutongGames.PlayMaker.Tooltip("The event you want to send.")]
		public FsmEvent remoteEvent;

		public FsmVector2 vector2Data;

		[ActionSection("Optionally target a Network Object")]
		[UIHint(UIHint.Variable)]
		public FsmObject networkObjectTarget;
		public FsmBool doNothingIfNull;
		public override void OnEnter()
        {
            if (networkObjectTarget.Value == null && doNothingIfNull.Value == false)
            {
                PlaymakerFusionNetworkRunner.PFNR.rpcHandler.TargetAll(remoteEvent.Name, vector2Data.Value);
            }
			else if (doNothingIfNull.Value == false)
            {
				PlaymakerFusionNetworkRunner.PFNR.rpcHandler.TargetObject((NetworkObject)networkObjectTarget.Value, remoteEvent.Name, vector2Data.Value);
			}


            Finish();
		}


	}

}
