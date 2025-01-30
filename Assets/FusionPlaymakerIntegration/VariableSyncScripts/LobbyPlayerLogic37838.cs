//this script created automatically using PlaymakerFusionSetupSyncVariables
using Fusion;
using HutongGames.PlayMaker;
using UnityEngine;

public class LobbyPlayerLogic37838 : NetworkBehaviour
{
public PlayMakerFSM fsmSource;

[UnityHeader("Strings")]
[Networked]
[Capacity(16)]
public string nickname {get;set;}
private FsmString fsmnickname;



private void Start()
{
fsmnickname = fsmSource.FsmVariables.FindFsmString("nickname");
}

private void Update()
{
if(HasStateAuthority)
{
nickname = fsmnickname.Value;

}else
{
fsmnickname.Value = nickname;

}}}