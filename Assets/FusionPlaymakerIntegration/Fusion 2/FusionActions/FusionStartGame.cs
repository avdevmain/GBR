using Fusion;
using HutongGames.PlayMaker;
using System.Collections.Generic;
using UnityEngine;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;

namespace GooglyEyesGames.PlayMaker.Fusion
{

	[ActionCategory("Fusion")]
	public class FusionStartGame : FsmStateAction
	{

        public FsmString sessionName;
        [Tooltip("Set false if you want it to be a private room and hidden from lobby lists.")]
        public FsmBool isVisible;

        [ActionSection("Optional: Leave as Defaults if you want.")]
        public FsmString customLobbyName;
        public FsmInt playerCount;

        [ObjectType(typeof(FusionRegion))]
        public FsmEnum region;
        private string regionToken;

        [ActionSection("Optional: Separate your properties as Key/Value pairs \nwith a comma. For example 'gameMode,captureTheFlag'.")]
        public FsmString[] customSessionProperties;


        public override void Reset()
        {
            sessionName = null;
            isVisible = true;
            customLobbyName = null;
            playerCount = -1;
            region = null;
        }
        public override void OnEnter()
        {
            if (!region.IsNone)
            {
                GetRegionToken();
            }
            else
            {
                regionToken = null;
            }
            Dictionary<string, SessionProperty> properties = new Dictionary<string, SessionProperty>();
            if (customSessionProperties.Length > 0)
            {
                foreach (FsmString pair in customSessionProperties)
                {
                    string[] keyValue = pair.Value.Split(',');
                    string key = keyValue[0];
                    string value = keyValue[1];
                    SessionProperty property = value;
                    properties.Add(key, property);
                }
            }
            PlaymakerFusionNetworkRunner.PFNR.StartGame(sessionName.Value, isVisible.Value, regionToken, properties, customLobbyName.Value, playerCount.Value);
            Finish();
		}

        private void GetRegionToken()
        {
            switch (region.Value)
            {
                case FusionRegion.Asia:
                    regionToken = "asia";
                    break;
                case FusionRegion.China:
                    regionToken = "cn";
                    break;
                case FusionRegion.Europe:
                    regionToken = "eu";
                    break;
                case FusionRegion.HongKong:
                    regionToken = "hk";
                    break;
                case FusionRegion.Japan:
                    regionToken = "jp";
                    break;
                case FusionRegion.SouthAmerica:
                    regionToken = "sa";
                    break;
                case FusionRegion.SouthKorea:
                    regionToken = "kr";
                    break;
                case FusionRegion.USAEast:
                    regionToken = "us";
                    break;
                case FusionRegion.USAWest:
                    regionToken = "usw";
                    break;
                case FusionRegion.Default:
                    regionToken = null;
                    break;
            }
        }
    }

}
