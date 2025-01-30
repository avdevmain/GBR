using Fusion;
using HutongGames.PlayMaker;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GooglyEyesGames.PlayMaker.Fusion
{

	[ActionCategory("Fusion")]
    [Tooltip("Gets the GameObject all players set as local object.")]
    public class FusionGetAllPlayersObject : FsmStateAction
	{

        [UIHint(UIHint.Variable)]
        [ArrayEditor(VariableType.GameObject)]
        public FsmArray playerObjects;

        public override void OnEnter()
        {

            NetworkRunner runner = PlaymakerFusionNetworkRunner.PFNR._runner;

            playerObjects.Resize(runner.ActivePlayers.Count());
            List<PlayerRef> playerList = runner.ActivePlayers.ToList();

            for (int i = 0; i < playerList.Count(); i++)
            {
                PlayerRef player = playerList[i];
                NetworkObject playerObject = runner.GetPlayerObject(player);
                playerObjects.Set(i, playerObject.gameObject);
            }

           
            Finish();
        }

    }

}
