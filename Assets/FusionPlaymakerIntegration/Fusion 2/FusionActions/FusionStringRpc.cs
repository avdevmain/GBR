using Fusion;
using HutongGames.PlayMaker;
using UnityEngine;

namespace GooglyEyesGames.PlayMaker.Fusion
{

	[ActionCategory("Fusion")]
	public class FusionStringRpc : FsmStateAction
	{
		[RequiredField]
		[HutongGames.PlayMaker.Tooltip("The event you want to send.")]
		public FsmEvent remoteEvent;

		public FsmString stringData;

		[ActionSection("Optionally target a Network Object")]
		[UIHint(UIHint.Variable)]
		public FsmObject networkObjectTarget;
		public FsmBool doNothingIfNull;
		public override void OnEnter()
        {
            if (networkObjectTarget.Value == null && doNothingIfNull.Value == false)
            {
                PlaymakerFusionNetworkRunner.PFNR.rpcHandler.TargetAll(remoteEvent.Name, stringData.Value);
            }
			else if (doNothingIfNull.Value == false)
            {
				PlaymakerFusionNetworkRunner.PFNR.rpcHandler.TargetObject((NetworkObject)networkObjectTarget.Value, remoteEvent.Name, stringData.Value);
			}


            Finish();
		}


	}

}
