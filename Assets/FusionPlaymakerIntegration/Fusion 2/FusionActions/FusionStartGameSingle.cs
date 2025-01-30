using HutongGames.PlayMaker;

namespace GooglyEyesGames.PlayMaker.Fusion
{

	[ActionCategory("Fusion")]
	public class FusionStartGameSingle : FsmStateAction
	{

        public FsmString sessionName;
        [Tooltip("Set false if you want it to be a private room and hidden from lobby lists.")]
        public FsmBool isVisible;


        public override void Reset()
        {
            sessionName = null;
            isVisible = true;
        }
        public override void OnEnter()
		{
            PlaymakerFusionNetworkRunner.PFNR.StartGameSingle(sessionName.Value, isVisible.Value);
            Finish();
		}
    }

}
