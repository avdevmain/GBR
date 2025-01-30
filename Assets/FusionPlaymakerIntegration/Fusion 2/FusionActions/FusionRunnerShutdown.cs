using Fusion;
using GooglyEyesGames.PlayMaker.Fusion;
using HutongGames.PlayMaker;

namespace GooglyEyesGames.PlayMaker.Actions.Fusion
{
    [ActionCategory("Fusion")]
    [HutongGames.PlayMaker.Tooltip("To leave a room, or disconnect completely, you have to shutdown the network runner.")]
    public class FusionRunnerShutdown : FsmStateAction
    {
        public override void OnEnter()
        {

            PlaymakerFusionNetworkRunner.PFNR._runner.Shutdown(false);

            Finish();
        }
    }
}

