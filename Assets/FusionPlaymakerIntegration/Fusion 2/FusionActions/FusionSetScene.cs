#if !FUSION2
using Fusion;
using HutongGames.PlayMaker;
using System;
using System.Collections.Generic;

namespace GooglyEyesGames.PlayMaker.Fusion
{

	[ActionCategory("Fusion")]
    [Tooltip("")]
    public class FusionSetScene : FsmStateAction
	{
        [RequiredField]
        public FsmInt sceneIndex;

        public override void Reset()
        {
            sceneIndex = null;
        }
        public override void OnEnter()
        {

            PlaymakerFusionNetworkRunner.PFNR._runner.SetActiveScene(sceneIndex.Value);

            Finish();
        }

    }

}
#endif