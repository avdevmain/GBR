using Fusion;
using HutongGames.PlayMaker;
using UnityEngine;

namespace GooglyEyesGames.PlayMaker.Fusion
{

	[ActionCategory("Fusion")]
    [HutongGames.PlayMaker.Tooltip("Gets the NetworkObject component of a GameObject.")]
    public class FusionGetNetworkObjectComponent : FsmStateAction
	{

        [RequiredField]
        public FsmOwnerDefault gameObject;

        [UIHint(UIHint.Variable)]
        public FsmObject networkObjectComponent;

        public override void Reset()
        {
            gameObject = null;
            networkObjectComponent = null;
        }
        public override void OnEnter()
        {

            GameObject go = Fsm.GetOwnerDefaultTarget(gameObject);
            if (go == null) return;

            networkObjectComponent.Value = go.GetComponent<NetworkObject>();

            Finish();
        }

    }

}
