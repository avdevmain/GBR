using Fusion;
using HutongGames.PlayMaker;
using System;

namespace GooglyEyesGames.PlayMaker.Fusion
{

	[ActionCategory("Fusion")]
    [Tooltip("Gets the number of players in the session.")]
    public class FusionGetPlayerCount : FsmStateAction
	{
        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmInt playerCount;

        public override void Reset()
        {
            playerCount = null;
        }
        public override void OnEnter()
        {
            playerCount.Value = PlaymakerFusionNetworkRunner.PFNR._runner.SessionInfo.PlayerCount;
            Finish();
        }

    }

}
