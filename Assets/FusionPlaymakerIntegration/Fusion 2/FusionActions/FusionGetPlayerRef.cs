using Fusion;
using HutongGames.PlayMaker;
using System;
using System.Collections.Generic;

namespace GooglyEyesGames.PlayMaker.Fusion
{

	[ActionCategory("Fusion")]
    [Tooltip("")]
    public class FusionGetPlayerRef : FsmStateAction
	{

        [UIHint(UIHint.Variable)]
        public FsmInt playerRef;

        public override void Reset()
        {
            playerRef = -1;
        }
        public override void OnEnter()
        {

            playerRef.Value = PlaymakerFusionNetworkRunner.PFNR._runner.LocalPlayer.PlayerId;

            Finish();
        }

    }

}
