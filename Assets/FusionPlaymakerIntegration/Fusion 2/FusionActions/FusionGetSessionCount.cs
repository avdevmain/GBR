using Fusion;
using HutongGames.PlayMaker;
using System;

namespace GooglyEyesGames.PlayMaker.Fusion
{

	[ActionCategory("Fusion")]
    [Tooltip("Gets the number of active sessions.")]
    public class FusionGetSessionCount : FsmStateAction
	{
        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmInt sessionCount;

        public override void Reset()
        {
            sessionCount = null;
        }
        public override void OnEnter()
        {
            sessionCount.Value = PlaymakerFusionNetworkRunner.PFNR.sessions.Count;
            Finish();
        }

    }

}
