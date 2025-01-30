using Fusion;
using HutongGames.PlayMaker;
using System;
using System.Collections.Generic;
using System.Linq;
namespace GooglyEyesGames.PlayMaker.Fusion
{

	[ActionCategory("Fusion")]
    [Tooltip("Set if Session is Visible in Room List.")]
    public class FusionSetSessionIsVisible: FsmStateAction
	{

        public FsmBool isVisible;


        public override void OnEnter()
        {

            PlaymakerFusionNetworkRunner.PFNR._runner.SessionInfo.IsVisible = isVisible.Value;

            Finish();
        }

    }

}
