using UnityEditor;
using UnityEditor.Compilation;
using UnityEngine;

[CustomEditor(typeof(PlaymakerFusionSetupSyncVariables))]
public class PlaymakerFusionSetupSyncVariablesEditor : Editor
{
    private PlaymakerFusionSetupSyncVariables targetScript;
    private bool step1Clicked = false;
    private bool step2Clicked = false;

    public override void OnInspectorGUI()
    {
        EditorGUILayout.LabelField("Please Note:", EditorStyles.boldLabel);
        EditorGUILayout.HelpBox("Variables of types Array, Enum, and Rect can still be used, but you must preface their names with 'network'. \n\n" +
            "Fusion requires you set capacity/length of Arrays and Strings.\n" +
            "\nFor example:\n\nnetworkArray_8 would be a networked array with max capacity of '8'.\n\n" +
            "The capcities/lengths you can use are:\n\n" +
            "_2, _4, _8, _16, _32, _64, _128, _256, _512", MessageType.Info);

        base.OnInspectorGUI();

        GUILayout.Space(10);

        EditorGUI.BeginDisabledGroup(step1Clicked); // Disable button if step 1 has been clicked
        if (!EditorApplication.isPlaying && GUILayout.Button(step1Clicked ? "Step 1: Network Sync Variables Set Up" : "Step 1: Setup Network Sync Variables"))
        {
            step1Clicked = true;
            Debug.Log("Setting Up Network Sync Variables. Please Wait...");
            targetScript = (PlaymakerFusionSetupSyncVariables)target;
            targetScript.FindNetworkSyncVaribles();
            
        }
        EditorGUI.EndDisabledGroup();

        GUILayout.Space(10);

        EditorGUI.BeginDisabledGroup(!step1Clicked || step2Clicked); // Disable button if step 1 has not been clicked or step 2 has been clicked
        if (!EditorApplication.isPlaying && GUILayout.Button(step2Clicked ? "Step 2: Components Added" : "Step 2: Add Components to GameObject"))
        {
            Debug.Log("Adding Components to GameObject. Please Wait...");
            targetScript = (PlaymakerFusionSetupSyncVariables)target;
            targetScript.AddComponents();
            step2Clicked = true;
        }
        EditorGUI.EndDisabledGroup();
    }
}
