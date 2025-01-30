using Fusion;
using HutongGames.PlayMaker;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;

namespace GooglyEyesGames.PlayMaker.Fusion
{

    [ActionCategory("Fusion")]
    [Tooltip("Gets the active session's info.")]
    public class FusionGetThisSessionInfo : FsmStateAction
    {

        [UIHint(UIHint.Variable)]
        public FsmBool isOpen;

        [UIHint(UIHint.Variable)]
        public FsmBool isValid;

        [UIHint(UIHint.Variable)]
        public FsmBool isVisible;

        [UIHint(UIHint.Variable)]
        public FsmInt maxPlayers;

        [UIHint(UIHint.Variable)]
        public FsmString name;

        [UIHint(UIHint.Variable)]
        public FsmInt playerCount;

        [UIHint(UIHint.Variable)]
        [ArrayEditor(VariableType.String)]
        [Tooltip("Each array entry is a key/value pair.")]
        public FsmArray properties;

        [UIHint(UIHint.Variable)]
        public FsmString region;


        public override void OnEnter()
        {
            if ((PlaymakerFusionNetworkRunner.PFNR != null) && (PlaymakerFusionNetworkRunner.PFNR._runner != null) && (PlaymakerFusionNetworkRunner.PFNR._runner.SessionInfo != null))
            {
                GetSessionInfo();
            }
            else
            {
                Debug.LogWarning("Attempted to GetSessionInfo when NOT connected to a session!");
            }

            Finish();
        }

        private void GetSessionInfo()
        {
            SessionInfo sessionInfo = PlaymakerFusionNetworkRunner.PFNR._runner.SessionInfo;

            isOpen.Value = sessionInfo.IsOpen;
            isValid.Value = sessionInfo.IsValid;
            isVisible.Value = sessionInfo.IsVisible;
            maxPlayers.Value = sessionInfo.MaxPlayers;
            name.Value = sessionInfo.Name;
            playerCount.Value = sessionInfo.PlayerCount;


            properties.Clear();

            if (sessionInfo.Properties != null)
            {
                properties.Resize(sessionInfo.Properties.Count);

                for (int i = 0; i < sessionInfo.Properties.Count; i++)
                {
                    string key = sessionInfo.Properties.ElementAt(i).Key;
                    string value = sessionInfo.Properties.ElementAt(i).Value;
                    string pair = key + "," + value;
                    properties.Set(i, pair);
                }
            }




            region.Value = sessionInfo.Region;
        }

    }

}
