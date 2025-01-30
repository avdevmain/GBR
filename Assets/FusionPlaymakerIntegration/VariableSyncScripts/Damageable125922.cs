//this script created automatically using PlaymakerFusionSetupSyncVariables
using Fusion;
using HutongGames.PlayMaker;
using UnityEngine;

public class Damageable125922 : NetworkBehaviour
{
public PlayMakerFSM fsmSource;

[UnityHeader("Ints")]
[Networked]
public int healthCurrent {get;set;}
private FsmInt fsmhealthCurrent;

[Networked]
public int score {get;set;}
private FsmInt fsmscore;



private void Start()
{
fsmhealthCurrent = fsmSource.FsmVariables.FindFsmInt("healthCurrent");
fsmscore = fsmSource.FsmVariables.FindFsmInt("score");
}

private void Update()
{
if(HasStateAuthority)
{
healthCurrent = fsmhealthCurrent.Value;
score = fsmscore.Value;

}else
{
fsmhealthCurrent.Value = healthCurrent;
fsmscore.Value = score;

}}}