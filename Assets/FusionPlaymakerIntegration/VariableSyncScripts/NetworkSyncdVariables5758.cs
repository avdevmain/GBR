//this script created automatically using PlaymakerFusionSetupSyncVariables
using Fusion;
using HutongGames.PlayMaker;
using UnityEngine;

public class NetworkSyncdVariables5758 : NetworkBehaviour
{
public PlayMakerFSM fsmSource;

[UnityHeader("Floats")]
[Networked]
public float networkPower {get;set;}
private FsmFloat fsmnetworkPower;

[UnityHeader("Ints")]
[Networked]
public int networkSpin {get;set;}
private FsmInt fsmnetworkSpin;



private void Start()
{
fsmnetworkPower = fsmSource.FsmVariables.FindFsmFloat("networkPower");
fsmnetworkSpin = fsmSource.FsmVariables.FindFsmInt("networkSpin");
}

private void Update()
{
if(HasStateAuthority)
{
networkPower = fsmnetworkPower.Value;
networkSpin = fsmnetworkSpin.Value;

}else
{
fsmnetworkPower.Value = networkPower;
fsmnetworkSpin.Value = networkSpin;

}}}