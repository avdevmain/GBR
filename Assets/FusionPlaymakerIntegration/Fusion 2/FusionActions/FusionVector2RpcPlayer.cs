using Fusion;
using HutongGames.PlayMaker;
using UnityEngine;

namespace GooglyEyesGames.PlayMaker.Fusion
{

	[ActionCategory("Fusion")]
	public class FusionVector2RpcPlayer : FsmStateAction
	{
		[RequiredField]
		[HutongGames.PlayMaker.Tooltip("The int representing the PlayerRef of the player you want to recieve the RPC.")]
		public FsmInt playerNumber;

		[RequiredField]
		[HutongGames.PlayMaker.Tooltip("The event you want to send.")]
		public FsmEvent remoteEvent;

		public FsmVector2 vector2Data;
		public override void OnEnter()
		{
			PlaymakerFusionNetworkRunner.PFNR.rpcHandler.TargetPlayer(playerNumber.Value, remoteEvent.Name, vector2Data.Value);

			Finish();
		}


	}

}
