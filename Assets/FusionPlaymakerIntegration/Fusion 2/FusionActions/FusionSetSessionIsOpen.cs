using Fusion;
using HutongGames.PlayMaker;
using System;
using System.Collections.Generic;
using System.Linq;
namespace GooglyEyesGames.PlayMaker.Fusion
{

	[ActionCategory("Fusion")]
    [Tooltip("Sets if Session is Open for others to join.")]
    public class FusionSetSessionIsOpen : FsmStateAction
	{

        public FsmBool isOpen;


        public override void OnEnter()
        {
            PlaymakerFusionNetworkRunner.PFNR._runner.SessionInfo.IsOpen = isOpen.Value;

            Finish();
        }

    }

}
