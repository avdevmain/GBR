using Fusion;
using HutongGames.PlayMaker;

namespace GooglyEyesGames.PlayMaker.Actions.Fusion
{
    [ActionCategory("Fusion")]
    [HutongGames.PlayMaker.Tooltip("Returns Player ID of who owns the NetworkObject.")]
    public class FusionObjectWhoHasStateAuthority : FsmStateAction
    {
        public FsmOwnerDefault gameObject;

        [UIHint(UIHint.Variable)]
        public FsmInt playerWithStateAuthority;


        public override void Reset()
        {
            gameObject = null;
            playerWithStateAuthority = null;
        }
        public override void OnEnter()
        {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            if (go.GetComponent<NetworkObject>() != null)
            {
                playerWithStateAuthority.Value = go.GetComponent<NetworkObject>().StateAuthority.PlayerId;
            }
            else
            {
                playerWithStateAuthority.Value = -1;
            }


            Finish();
        }
    }
}

