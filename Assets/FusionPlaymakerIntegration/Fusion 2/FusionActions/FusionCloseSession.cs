using HutongGames.PlayMaker;

namespace GooglyEyesGames.PlayMaker.Fusion
{

	[ActionCategory("Fusion")]
    [Tooltip("Closing a session stops future players from joining.")]
    public class FusionCloseSession : FsmStateAction
	{
        [Tooltip("isOpen should be false to close the room.")]
        public FsmBool isOpen;


        public override void Reset()
        {
            isOpen = false;
        }
        public override void OnEnter()
		{
            PlaymakerFusionNetworkRunner.PFNR._runner.SessionInfo.IsOpen = isOpen.Value;
            Finish();
		}
    }

}
