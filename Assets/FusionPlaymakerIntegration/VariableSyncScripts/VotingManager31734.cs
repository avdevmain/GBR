//this script created automatically using PlaymakerFusionSetupSyncVariables
using Fusion;
using HutongGames.PlayMaker;
using UnityEngine;

public class VotingManager31734 : NetworkBehaviour
{
public PlayMakerFSM fsmSource;

[UnityHeader("Bools")]
[Networked]
public NetworkBool bPlayer0_Ready {get;set;}
private FsmBool fsmbPlayer0_Ready;

[Networked]
public NetworkBool bPlayer1_Ready {get;set;}
private FsmBool fsmbPlayer1_Ready;

[Networked]
public NetworkBool bPlayer2_Ready {get;set;}
private FsmBool fsmbPlayer2_Ready;

[Networked]
public NetworkBool bPlayer3_Ready {get;set;}
private FsmBool fsmbPlayer3_Ready;

[Networked]
public int iVoteCount {get;set;}
private FsmInt fsmiVoteCount;



private void Start()
{
fsmbPlayer0_Ready = fsmSource.FsmVariables.FindFsmBool("bPlayer0_Ready");
fsmbPlayer1_Ready = fsmSource.FsmVariables.FindFsmBool("bPlayer1_Ready");
fsmbPlayer2_Ready = fsmSource.FsmVariables.FindFsmBool("bPlayer2_Ready");
fsmbPlayer3_Ready = fsmSource.FsmVariables.FindFsmBool("bPlayer3_Ready");
fsmiVoteCount = fsmSource.FsmVariables.FindFsmInt("iVoteCount");
}

private void Update()
{
if(HasStateAuthority)
{
bPlayer0_Ready = fsmbPlayer0_Ready.Value;
bPlayer1_Ready = fsmbPlayer1_Ready.Value;
bPlayer2_Ready = fsmbPlayer2_Ready.Value;
bPlayer3_Ready = fsmbPlayer3_Ready.Value;
iVoteCount = fsmiVoteCount.Value;

}else
{
fsmbPlayer0_Ready.Value = bPlayer0_Ready;
fsmbPlayer1_Ready.Value = bPlayer1_Ready;
fsmbPlayer2_Ready.Value = bPlayer2_Ready;
fsmbPlayer3_Ready.Value = bPlayer3_Ready;
fsmiVoteCount.Value = iVoteCount;

}}}