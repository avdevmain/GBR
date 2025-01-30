using Fusion;
using HutongGames.PlayMaker;
using UnityEngine;

namespace GooglyEyesGames.PlayMaker.Fusion
{

	[ActionCategory("Fusion")]
    [HutongGames.PlayMaker.Tooltip("Releases StateAuthority of a NetworkObject")]
    public class FusionReleaseStateAuthority : FsmStateAction
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

            go.GetComponent<NetworkObject>().ReleaseStateAuthority();
            Finish();
        }

    }

}
