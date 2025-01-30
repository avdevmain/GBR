using Fusion;
using HutongGames.PlayMaker;
using System;
using System.Collections.Generic;
using System.Linq;
namespace GooglyEyesGames.PlayMaker.Fusion
{

	[ActionCategory("Fusion")]
    [Tooltip("Updates the session custom properties. If you previously set custom properties, this will erase all old ones.")]
    public class FusionSetSessionCustomProperties : FsmStateAction
	{


        [ArrayEditor(VariableType.String)]
        [Tooltip("Each array entry is a key/value pair.")]
        public FsmArray properties;



        public override void OnEnter()
        {

            Dictionary<string, SessionProperty> _properties = new Dictionary<string, SessionProperty>();

            for (int i = 0; i < properties.Length; i++)
            {
                string pair = properties.Get(i).ToString();
                string[] pairArray = pair.Split(',');
                string key = pairArray[0];
                SessionProperty value = pairArray[1];
                _properties.Add(key, value);
            }

            PlaymakerFusionNetworkRunner.PFNR._runner.SessionInfo.UpdateCustomProperties(_properties);

            Finish();
        }

    }

}
