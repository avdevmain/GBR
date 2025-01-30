using Fusion;
using HutongGames.PlayMaker;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace GooglyEyesGames.PlayMaker.Fusion
{

	[ActionCategory("Fusion")]
    [HutongGames.PlayMaker.Tooltip("Gets the ID of the NetworkObject.")]
    public class FusionGetNetworkObjectId : FsmStateAction
	{

        [RequiredField]
        public FsmOwnerDefault gameObject;

        [UIHint(UIHint.Variable)]
        public FsmInt networkId;

        public override void Reset()
        {
            gameObject = null;
            networkId = null;
        }
        public override void OnEnter()
        {

            GameObject go = Fsm.GetOwnerDefaultTarget(gameObject);
            if (go == null) return;

            networkId.Value = (int)go.GetComponent<NetworkObject>().Id.Raw;

            Finish();
        }

    }

}
