using Fusion;
using HutongGames.PlayMaker;
using System;

namespace GooglyEyesGames.PlayMaker.Fusion
{

	[ActionCategory("Fusion")]
    [Tooltip("Get the ping of a player by Player ID. Displayed in miliseconds")]
    public class FusionGetPlayerPing : FsmStateAction
	{
        public FsmInt playerId;
        [RequiredField]
        [UIHint(UIHint.Variable)]
        [Tooltip("Store the value in an Int variable in this FSM.")]
        public FsmInt ping;
        public bool everyFrame;

        public override void Reset()
        {
            playerId = null;
            everyFrame = false;
        }
        public override void OnEnter()
        {
            ping.Value = CalculatePing();

            if (!everyFrame)
            {
                Finish();
            }
            
        }

        public override void OnUpdate()
        {
#if !FUSION2
            UnityEngine.Debug.Log(PlaymakerFusionNetworkRunner.PFNR._runner.GetPlayerRtt(playerId.Value));
            ping.Value = CalculatePing();
#endif
#if FUSION2
            UnityEngine.Debug.Log(PlaymakerFusionNetworkRunner.PFNR._runner.GetPlayerRtt(PlayerRef.FromIndex(playerId.Value)));
            ping.Value = CalculatePing();
#endif
        }

        private int CalculatePing()
        {
#if !FUSION2
            double dping = PlaymakerFusionNetworkRunner.PFNR._runner.GetPlayerRtt(playerId.Value) * 1000f;
            int ping = (int)Math.Round(dping);
            return ping;
#endif

#if FUSION2
            double dping = PlaymakerFusionNetworkRunner.PFNR._runner.GetPlayerRtt(PlayerRef.FromIndex(playerId.Value)) * 1000f;
            int ping = (int)Math.Round(dping);
            return ping;
#endif
        }
    }

}
