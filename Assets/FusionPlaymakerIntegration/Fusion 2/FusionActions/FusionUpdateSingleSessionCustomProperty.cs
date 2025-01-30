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
    [Tooltip("Updates a single currently existing session custom property.")]
    public class FusionUpdateSingleSessionCustomProperty : FsmStateAction
	{
        [RequiredField]
        public FsmString key;

        [RequiredField]
        public FsmString value;

        public override void OnEnter()
        {

            Dictionary<string, SessionProperty> _properties = new Dictionary<string, SessionProperty>();

            var currentProperties = PlaymakerFusionNetworkRunner.PFNR._runner.SessionInfo.Properties;


            foreach (var _key in currentProperties.Keys)
            {
                _properties.Add(_key, currentProperties[key.Value]);
            }

            if (_properties.ContainsKey(key.Value))
            {
                _properties[key.Value] = value.Value;
            }
            else
            {
                Debug.LogWarning("Attempted to update the value of a session key that doesn't exist.");
                Finish();
            }

            PlaymakerFusionNetworkRunner.PFNR._runner.SessionInfo.UpdateCustomProperties(_properties);

            Finish();
        }

    }

}
