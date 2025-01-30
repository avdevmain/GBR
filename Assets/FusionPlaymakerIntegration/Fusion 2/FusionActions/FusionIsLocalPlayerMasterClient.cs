using Fusion;
using HutongGames.PlayMaker;
using System;
using System.Collections.Generic;

namespace GooglyEyesGames.PlayMaker.Fusion
{

	[ActionCategory("Fusion")]
    [Tooltip("")]
    public class FusionIsLocalPlayerMasterClient : FsmStateAction
	{
        [UIHint(UIHint.Variable)]
        public FsmBool isMasterClient;
        public FsmEvent yesEvent;
        public FsmEvent noEvent;

        public override void Reset()
        {
            isMasterClient = false;
        }
        public override void OnEnter()
        {
            isMasterClient.Value = PlaymakerFusionNetworkRunner.PFNR._runner.IsSharedModeMasterClient;

            if (isMasterClient.Value)
            {
                Fsm.Event(yesEvent);
            }
            else
            {
                Fsm.Event(noEvent);
            }
            Finish();
        }

    }

}
