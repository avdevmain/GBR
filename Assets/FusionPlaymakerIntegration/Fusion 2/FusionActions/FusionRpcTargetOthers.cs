using Fusion;
using HutongGames.PlayMaker;
using UnityEngine;

namespace GooglyEyesGames.PlayMaker.Fusion
{

    [ActionCategory("Fusion")]
    public class FusionRpcTargetOthers : FsmStateAction
    {
        [RequiredField]
        [HutongGames.PlayMaker.Tooltip("The event you want to send.")]
        public FsmEvent remoteEvent;

        /*[ActionSection("Optionally target a Network Object")]
        [UIHint(UIHint.Variable)]
        public FsmObject networkObjectTarget;
        public FsmBool doNothingIfNull;*/
        public override void OnEnter()
        {
            PlaymakerFusionNetworkRunner.PFNR.rpcHandler.TargetOthers(remoteEvent.Name);


            Finish();
        }


    }

}
