using Fusion;
using HutongGames.PlayMaker;

namespace GooglyEyesGames.PlayMaker.Fusion
{

	[ActionCategory("Fusion")]
	public class FusionDestroyPlayer : FsmStateAction
	{
		private PlayerRef player;
        public override void OnEnter()
		{
			player = PlaymakerFusionNetworkRunner.PFNR.playerRef;
			NetworkObject playerObject = PlaymakerFusionNetworkRunner.PFNR._runner.GetPlayerObject(player);
			PlaymakerFusionNetworkRunner.PFNR._runner.Despawn(playerObject);

            Finish();
		}


	}

}
