using HutongGames.PlayMakerEditor;
using UnityEditor;
using UnityEngine;
using Fusion;

[InitializeOnLoad]
public class FusionEnablePlaymakerNetworkSyncBool
{
    static FusionEnablePlaymakerNetworkSyncBool()
    {
        EnableNetworkSyncBool();
    }

    private static void EnableNetworkSyncBool()
    {
        FsmEditorSettings.ShowNetworkSync = true;
    }
}
