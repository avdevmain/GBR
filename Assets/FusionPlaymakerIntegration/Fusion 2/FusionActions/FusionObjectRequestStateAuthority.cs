using Fusion;
using HutongGames.PlayMaker;

namespace GooglyEyesGames.PlayMaker.Actions.Fusion
{
    [ActionCategory("Fusion")]
    [HutongGames.PlayMaker.Tooltip("Requests State Authority of the NetworkObject.")]
    public class FusionObjectRequestStateAuthority : FsmStateAction
    {
        public FsmOwnerDefault gameObject;

        public override void Reset()
        {
            gameObject = null;
        }
        public override void OnEnter()
        {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            go.GetComponent<NetworkObject>().RequestStateAuthority();

            Finish();
        }
    }
}

