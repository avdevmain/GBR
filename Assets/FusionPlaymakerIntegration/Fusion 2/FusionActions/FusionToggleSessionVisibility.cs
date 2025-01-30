using HutongGames.PlayMaker;

namespace GooglyEyesGames.PlayMaker.Fusion
{

	[ActionCategory("Fusion")]
    [Tooltip("Visibility impacts room showing up in Lobby lists.")]
    public class FusionToggleSessionVisibility : FsmStateAction
	{
        [Tooltip("isOpen should be false to close the room.")]
        public FsmBool isVisible;

        public override void Reset()
        {
            isVisible = false;
        }
        public override void OnEnter()
		{
            PlaymakerFusionNetworkRunner.PFNR._runner.SessionInfo.IsVisible = isVisible.Value;
            Finish();
		}
    }

}
