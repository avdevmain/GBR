using Fusion;
using HutongGames.PlayMaker;

namespace GooglyEyesGames.PlayMaker.Actions.Fusion
{
    [ActionCategory("Fusion")]
    [HutongGames.PlayMaker.Tooltip("True if you have State Authority of the NetworkObject.")]
    public class FusionObjectHasStateAuthority : FsmStateAction
    {
        public FsmOwnerDefault gameObject;
        [UIHint(UIHint.Variable)]
        public FsmBool hasStateAuthority;
        public FsmEvent hasAuthorityEvent;
        public FsmEvent noAuthorityEvent;


        public override void Reset()
        {
            gameObject = null;
            hasStateAuthority = false;
            hasAuthorityEvent = null;
            noAuthorityEvent = null;
        }
        public override void OnEnter()
        {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            if (go.GetComponent<NetworkObject>() != null)
            {
                bool authority = go.GetComponent<NetworkObject>().HasStateAuthority;
                hasStateAuthority.Value = authority;
                if (authority)
                {

                    Fsm.Event(hasAuthorityEvent);
                    Finish();
                }
                else
                {
                    Fsm.Event(noAuthorityEvent);
                    Finish();
                }
            }
            else
            {
                hasStateAuthority.Value = false;
                Fsm.Event(noAuthorityEvent);
                Finish();
            }


        }
    }
}

