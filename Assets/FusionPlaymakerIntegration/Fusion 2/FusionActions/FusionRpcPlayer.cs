using Fusion;
using HutongGames.PlayMaker;
using UnityEngine;

namespace GooglyEyesGames.PlayMaker.Fusion
{

	[ActionCategory("Fusion")]
	public class FusionRpcPlayer : FsmStateAction
	{
		public FsmInt playerNumber;
		[RequiredField]
		[HutongGames.PlayMaker.Tooltip("The event you want to send.")]
		public FsmEvent remoteEvent;

		public override void OnEnter()
        {
			PlaymakerFusionNetworkRunner.PFNR.rpcHandler.TargetPlayer(playerNumber.Value, remoteEvent.Name);

            Finish();
		}


	}

}
