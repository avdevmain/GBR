using Fusion;
using HutongGames.PlayMaker;
using System;
using System.Collections.Generic;

namespace GooglyEyesGames.PlayMaker.Fusion
{

	[ActionCategory("Fusion")]
    [Tooltip("")]
    public class FusionGetScene : FsmStateAction
	{
        [UIHint(UIHint.Variable)]
        public FsmInt sceneIndex;

        public override void Reset()
        {
            sceneIndex = null;
        }
        public override void OnEnter()
        {
#if !FUSION2
            sceneIndex.Value = PlaymakerFusionNetworkRunner.PFNR._runner.CurrentScene;
#endif
#if FUSION2
            sceneIndex.Value = PlaymakerFusionNetworkRunner.PFNR._runner.SceneManager.MainRunnerScene.buildIndex;
#endif

            Finish();
        }

    }

}
