using Fusion;
using HutongGames.PlayMaker;

namespace GooglyEyesGames.PlayMaker.Actions.Fusion
{
    [ActionCategory("Fusion")]
    public class FusionObjectHasInputAuthority : FsmStateAction
    {
        public FsmOwnerDefault gameObject;
        [UIHint(UIHint.Variable)]
        public FsmBool hasInputAuthority;
        public FsmEvent hasAuthorityEvent;
        public FsmEvent noAuthorityEvent;


        public override void Reset()
        {
            gameObject = null;
            hasInputAuthority = false;
            hasAuthorityEvent = null;
            noAuthorityEvent = null;
        }
        public override void OnEnter()
        {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);

            if (go.GetComponent<NetworkObject>() != null)
            {
                bool authority = go.GetComponent<NetworkObject>().HasInputAuthority;
                if (authority)
                {
                    hasInputAuthority.Value = true;
                    Fsm.Event(hasAuthorityEvent);
                    Finish();
                }
            }
            
            hasInputAuthority.Value = false;
            Fsm.Event(noAuthorityEvent);
            Finish();
        }
    }
}

