using Fusion;
using HutongGames.PlayMaker;
using System;
using System.Collections.Generic;

namespace GooglyEyesGames.PlayMaker.Fusion
{

	[ActionCategory("Fusion")]
    [Tooltip("You would use this, instead of starting game right away, if you wanted to pull up a Session List first to choose a session to join.")]
    public class FusionJoinSessionLobby : FsmStateAction
	{
        [RequiredField]
        public FsmString lobbyName;

        [ActionSection("Optional")]
        [ObjectType(typeof(FusionRegion))]
        public FsmEnum region;
        private string regionToken;

        public override void Reset()
        {
            lobbyName = null;
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

            PlaymakerFusionNetworkRunner.PFNR.ConnectToLobby(lobbyName.Value, regionToken);

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
