using Fusion;
using HutongGames.PlayMaker;
using System;
using System.Collections.Generic;

namespace GooglyEyesGames.PlayMaker.Fusion
{

	[ActionCategory("Fusion")]
    [Tooltip("Gets the GameObject you set as the local Object when you spawned it.")]
    public class FusionGetPlayerObject : FsmStateAction
	{

        public FsmInt playerRef;

        [UIHint(UIHint.Variable)]
        public FsmGameObject playerObject;

        public FsmEvent success;
        public FsmEvent failure;

        public override void Reset()
        {
            playerRef = -1;
        }
        public override void OnEnter()
        {
#if !FUSION2
            NetworkObject localObject = PlaymakerFusionNetworkRunner.PFNR._runner.GetPlayerObject(playerRef.Value);
            if (localObject != null)
            {
                playerObject.Value = localObject.gameObject;
                Fsm.Event(success);
            }
            else
            {
                Fsm.Event(failure);
            }
#endif
#if FUSION2
            NetworkObject localObject = PlaymakerFusionNetworkRunner.PFNR._runner.GetPlayerObject(PlayerRef.FromIndex(playerRef.Value));
            if (localObject != null)
            {
                playerObject.Value = localObject.gameObject;
                Fsm.Event(success);
            }
            else
            {
                Fsm.Event(failure);
            }
#endif

            Finish();
        }

    }

}
