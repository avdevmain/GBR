//this script created automatically using PlaymakerFusionSetupSyncVariables
using Fusion;
using HutongGames.PlayMaker;
using UnityEngine;

public class Variables113958 : NetworkBehaviour
{
public PlayMakerFSM fsmSource;

[UnityHeader("Bools")]
[Networked]
public NetworkBool isBusy {get;set;}
private FsmBool fsmisBusy;



private void Start()
{
fsmisBusy = fsmSource.FsmVariables.FindFsmBool("isBusy");
}

private void Update()
{
if(HasStateAuthority)
{
isBusy = fsmisBusy.Value;

}else
{
fsmisBusy.Value = isBusy;

}}}