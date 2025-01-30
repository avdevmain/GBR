using Fusion;
using HutongGames.PlayMaker;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;

namespace GooglyEyesGames.PlayMaker.Fusion
{

	[ActionCategory("Fusion")]
    [Tooltip("Gets the value of a currently existing session custom property key.")]
    public class FusionGetSingleSessionCustomProperty : FsmStateAction
	{
        [RequiredField]
        public FsmString key;

        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmString value;

        public override void OnEnter()
        {


            var currentProperties = PlaymakerFusionNetworkRunner.PFNR._runner.SessionInfo.Properties;

            if (currentProperties.ContainsKey(key.Value))
            {
                value.Value = currentProperties[key.Value];
            }
            else
            {
                Debug.LogWarning("There is no Session Proper with key: " + key.Value);
            }

            Finish();
        }

    }

}
