using Fusion;
using HutongGames.PlayMaker;
using UnityEngine;

namespace GooglyEyesGames.PlayMaker.Fusion
{

	[ActionCategory("Fusion")]
    [HutongGames.PlayMaker.Tooltip("Requests StateAuthority of a NetworkObject")]
    public class FusionRequestStateAuthority : FsmStateAction
	{

        [RequiredField]
        public FsmOwnerDefault gameObject;

        public override void Reset()
        {
            gameObject = null;
        }
        public override void OnEnter()
        {

            GameObject go = Fsm.GetOwnerDefaultTarget(gameObject);
            if (go == null) return;

            go.GetComponent<NetworkObject>().RequestStateAuthority();
            Finish();
        }

    }

}
