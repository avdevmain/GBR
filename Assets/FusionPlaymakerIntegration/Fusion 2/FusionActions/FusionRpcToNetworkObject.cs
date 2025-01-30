using Fusion;
using HutongGames.PlayMaker;
using UnityEngine;

namespace GooglyEyesGames.PlayMaker.Fusion
{

	[ActionCategory("Fusion")]
	public class FusionRpcToNetworkObject : FsmStateAction
	{
		[RequiredField]
		public FsmObject networkObjectTarget;


		[RequiredField]
		[HutongGames.PlayMaker.Tooltip("The event you want to send.")]
		public FsmEvent remoteEvent;

		public override void OnEnter()
		{
			if (networkObjectTarget.Value != null)
			PlaymakerFusionNetworkRunner.PFNR.rpcHandler.TargetObject((NetworkObject)networkObjectTarget.Value, remoteEvent.Name);

			Finish();
		}


	}

}
