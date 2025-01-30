using Fusion;
using HutongGames.PlayMaker;
using UnityEngine;

namespace GooglyEyesGames.PlayMaker.Fusion
{

	[ActionCategory("Fusion")]
	public class FusionStringRpcPlayer : FsmStateAction
	{
		[RequiredField]
		[HutongGames.PlayMaker.Tooltip("The int representing the PlayerRef of the player you want to recieve the RPC.")]
		public FsmInt playerNumber;

		[RequiredField]
		[HutongGames.PlayMaker.Tooltip("The event you want to send.")]
		public FsmEvent remoteEvent;

		public FsmString stringData;
		public override void OnEnter()
		{
			PlaymakerFusionNetworkRunner.PFNR.rpcHandler.TargetPlayer(playerNumber.Value, remoteEvent.Name, stringData.Value);

			Finish();
		}


	}

}
