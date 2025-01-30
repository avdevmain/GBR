using Fusion;
using HutongGames.PlayMaker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
public class PlaymakerFusionSetupSyncVariables : MonoBehaviour
{


    public PlayMakerFSM[] fsmsToCheck;
    private string path = "Assets/FusionPlaymakerIntegration/VariableSyncScripts";
    private string[] scriptPaths = new string[0];

    private void Awake()
    {
        Debug.LogError("Gameobject: " + this.gameObject + " still has a PlaymakerFusionSetupSyncVariables component that hasn't finished setup. Its possible this was on a prefab, and Unity didn't save the changes. Try finishing setup, then create and delete an empty gameobject on your prefab so it saves.");
    }
    public void FindNetworkSyncVaribles()
    {
        if (scriptPaths != null && scriptPaths.Length > 0)
        {
            Array.Clear(scriptPaths, 0, 0);
        }



        if (!Directory.Exists(path))
        {
            // Create the directory if it doesn't exist
            Directory.CreateDirectory(path);
        }


        //I want to create a unique NetworkBehaviour for each FSM to sync variables
        foreach (PlayMakerFSM fsm in fsmsToCheck)
        {
            #region This Section Creates a Name for the NetworkBehaviour
            string fsmName = Regex.Replace(fsm.FsmName, @"\s+", "");
            fsmName = Regex.Replace(fsmName, "[^a-zA-Z0-9]", "");
            char c = Convert.ToChar(fsmName[0]);

            if (Char.IsDigit(c))
            {
                fsmName = "Z" + fsmName;
            }
            fsmName = fsmName.Substring(0, 1).ToUpper() + fsmName.Substring(1);
            string identifier = fsmName + gameObject.GetInstanceID().ToString();
            identifier = identifier.Replace("-", ""); // Remove hyphens

            #endregion

            #region This Section creates all the network variables

            string contents = "//this script created automatically using PlaymakerFusionSetupSyncVariables\nusing Fusion;\nusing HutongGames.PlayMaker;\nusing UnityEngine;\n\npublic class " + identifier + " : NetworkBehaviour\n{";


            NamedVariable[] variables = fsm.FsmVariables.GetAllNamedVariables();
            Array.Sort(variables, new NamedVariableComparer());

            contents += "\npublic PlayMakerFSM fsmSource;\n";
            //this is writing all the network variables to the new script file
            foreach (NamedVariable variable in variables)
            {
                if (variable.NetworkSync == true || variable.GetDisplayName().StartsWith("network"))
                {
                    switch (variable.VariableType)
                    {
                        //TODO: Come back to arrays
                        case VariableType.Array:
                            int capacity = GetCapacity(variable.GetDisplayName());
                            int index = Array.IndexOf(variables, variable);
                            if (index == 0)
                            {
                                //add header
                                contents += "\n[UnityHeader(\"Arrays\")]";
                            }
                            else if (variables[index - 1].VariableType != VariableType.Array)
                            {
                                contents += "\n[UnityHeader(\"Arrays\")]";
                            }
                            switch (variable.TypeConstraint)
                            {
                                case VariableType.Float:
                                    contents += "\n[Networked]\n";
                                    contents += "[Capacity(" + capacity + ")]\n";
                                    contents += "public NetworkArray<float> " + variable.GetDisplayName() + " => default;";
                                    contents += "\nprivate FsmArray fsm" + variable.GetDisplayName() + ";\n";
                                    break;
                                case VariableType.Int:
                                    contents += "\n[Networked]\n";
                                    contents += "[Capacity(" + capacity + ")]\n";
                                    contents += "public NetworkArray<int> " + variable.GetDisplayName() + " => default;";
                                    contents += "\nprivate FsmArray fsm" + variable.GetDisplayName() + ";\n";
                                    break;
                                case VariableType.Bool:
                                    contents += "\n[Networked]\n";
                                    contents += "[Capacity(" + capacity + ")]\n";
                                    contents += "public NetworkArray<bool> " + variable.GetDisplayName() + " => default;";
                                    contents += "\nprivate FsmArray fsm" + variable.GetDisplayName() + ";\n";
                                    break;
                                case VariableType.String:
                                    contents += "\n[Networked]\n";
                                    contents += "[Capacity(" + capacity + ")]\n";
                                    contents += "public NetworkArray<string> " + variable.GetDisplayName() + " => default;";
                                    contents += "\nprivate FsmArray fsm" + variable.GetDisplayName() + ";\n";
                                    break;
                                case VariableType.Vector2:
                                    contents += "\n[Networked]\n";
                                    contents += "[Capacity(" + capacity + ")]\n";
                                    contents += "public NetworkArray<Vector2> " + variable.GetDisplayName() + " => default;";
                                    contents += "\nprivate FsmArray fsm" + variable.GetDisplayName() + ";\n";
                                    break;
                                case VariableType.Vector3:
                                    contents += "\n[Networked]\n";
                                    contents += "[Capacity(" + capacity + ")]\n";
                                    contents += "public NetworkArray<Vector3> " + variable.GetDisplayName() + " => default;";
                                    contents += "\nprivate FsmArray fsm" + variable.GetDisplayName() + ";\n";
                                    break;
                                case VariableType.Color:
                                    contents += "\n[Networked]\n";
                                    contents += "[Capacity(" + capacity + ")]\n";
                                    contents += "public NetworkArray<Color> " + variable.GetDisplayName() + " => default;";
                                    contents += "\nprivate FsmArray fsm" + variable.GetDisplayName() + ";\n";
                                    break;
                                case VariableType.Rect:
                                    contents += "\n[Networked]\n";
                                    contents += "[Capacity(" + capacity + ")]\n";
                                    contents += "public NetworkArray<Rect> " + variable.GetDisplayName() + " => default;";
                                    contents += "\nprivate FsmArray fsm" + variable.GetDisplayName() + ";\n";
                                    break;
                                case VariableType.Quaternion:
                                    contents += "\n[Networked]\n";
                                    contents += "[Capacity(" + capacity + ")]\n";
                                    contents += "public NetworkArray<Quaternion> " + variable.GetDisplayName() + " => default;";
                                    contents += "\nprivate FsmArray fsm" + variable.GetDisplayName() + ";\n";
                                    break;
                                case VariableType.Enum:
                                    System.Type enumType2 = variable.ObjectType;
                                    contents += "\n[Networked]\n";
                                    contents += "[Capacity(" + capacity + ")]\n";
                                    contents += "public NetworkArray<" + enumType2 + "> " + variable.GetDisplayName() + " => default;";
                                    contents += "\nprivate FsmArray fsm" + variable.GetDisplayName() + ";\n";
                                    break;
                                default:
                                    Debug.LogError("Array Variable of type " + variable.VariableType + " from FSM: " + fsm + " can not be Networked.");
                                    break;

                            }
                            break;
                        case VariableType.Bool:
                            index = Array.IndexOf(variables, variable);
                            if (index == 0)
                            {
                                //add header
                                contents += "\n[UnityHeader(\"Bools\")]";
                            }
                            else if (variables[index - 1].VariableType != VariableType.Bool)
                            {
                                contents += "\n[UnityHeader(\"Bools\")]";
                            }
                            contents += "\n[Networked]\npublic NetworkBool " + variable.GetDisplayName() + " {get;set;}";
                            contents += "\nprivate FsmBool fsm" + variable.GetDisplayName() + ";\n";
                            break;
                        case VariableType.Color:
                            index = Array.IndexOf(variables, variable);
                            if (index == 0)
                            {
                                //add header
                                contents += "\n[UnityHeader(\"Colors\")]";
                            }
                            else if (variables[index - 1].VariableType != VariableType.Color)
                            {
                                contents += "\n[UnityHeader(\"Colors\")]";
                            }
                            contents += "\n[Networked]\npublic Color " + variable.GetDisplayName() + " {get;set;}";
                            contents += "\nprivate FsmColor fsm" + variable.GetDisplayName() + ";\n";
                            break;
                        case VariableType.Enum:
                            index = Array.IndexOf(variables, variable);
                            if (index == 0)
                            {
                                //add header
                                contents += "\n[UnityHeader(\"Enums\")]";
                            }
                            else if (variables[index - 1].VariableType != VariableType.Enum)
                            {
                                contents += "\n[UnityHeader(\"Enums\")]";
                            }
                            System.Type enumType = variable.ObjectType;
                            contents += "\n[Networked]\npublic " + enumType + " " + variable.GetDisplayName() + " {get;set;}";
                            contents += "\nprivate FsmEnum fsm" + variable.GetDisplayName() + ";\n";
                            break;
                        case VariableType.Float:
                            index = Array.IndexOf(variables, variable);
                            if (index == 0)
                            {
                                //add header
                                contents += "\n[UnityHeader(\"Floats\")]";
                            }
                            else if (variables[index - 1].VariableType != VariableType.Float)
                            {
                                contents += "\n[UnityHeader(\"Floats\")]";
                            }
                            contents += "\n[Networked]\npublic float " + variable.GetDisplayName() + " {get;set;}";
                            contents += "\nprivate FsmFloat fsm" + variable.GetDisplayName() + ";\n";
                            break;
                        case VariableType.Int:
                            index = Array.IndexOf(variables, variable);
                            if (index == 0)
                            {
                                //add header
                                contents += "\n[UnityHeader(\"Ints\")]";
                            }
                            else if (variables[index - 1].VariableType != VariableType.Int)
                            {
                                contents += "\n[UnityHeader(\"Ints\")]";
                            }
                            contents += "\n[Networked]\npublic int " + variable.GetDisplayName() + " {get;set;}";
                            contents += "\nprivate FsmInt fsm" + variable.GetDisplayName() + ";\n";
                            break;
                        case VariableType.Quaternion:
                            index = Array.IndexOf(variables, variable);
                            if (index == 0)
                            {
                                //add header
                                contents += "\n[UnityHeader(\"Quaternions\")]";
                            }
                            else if (variables[index - 1].VariableType != VariableType.Quaternion)
                            {
                                contents += "\n[UnityHeader(\"Quaternions\")]";
                            }
                            contents += "\n[Networked]\npublic Quaternion " + variable.GetDisplayName() + " {get;set;}";
                            contents += "\nprivate FsmQuaternion fsm" + variable.GetDisplayName() + ";\n";
                            break;
                        case VariableType.Rect:
                            index = Array.IndexOf(variables, variable);
                            if (index == 0)
                            {
                                //add header
                                contents += "\n[UnityHeader(\"Rects\")]";
                            }
                            else if (variables[index - 1].VariableType != VariableType.Rect)
                            {
                                contents += "\n[UnityHeader(\"Rects\")]";
                            }
                            contents += "\n[Networked]\npublic Rect " + variable.GetDisplayName() + " {get;set;}";
                            contents += "\nprivate FsmRect fsm" + variable.GetDisplayName() + ";\n";
                            break;
                        case VariableType.String:
                            capacity = GetCapacity(variable.GetDisplayName());
                            index = Array.IndexOf(variables, variable);
                            if (index == 0)
                            {
                                //add header
                                contents += "\n[UnityHeader(\"Strings\")]";
                            }
                            else if (variables[index - 1].VariableType != VariableType.String)
                            {
                                contents += "\n[UnityHeader(\"Strings\")]";
                            }
                            contents += "\n[Networked]\n";
                            contents += "[Capacity(" + capacity + ")]\n";
                            contents += "public string " + variable.GetDisplayName() + " {get;set;}";
                            contents += "\nprivate FsmString fsm" + variable.GetDisplayName() + ";\n";
                            break;
                        case VariableType.Vector2:
                            index = Array.IndexOf(variables, variable);
                            if (index == 0)
                            {
                                //add header
                                contents += "\n[UnityHeader(\"Vector2s\")]";
                            }
                            else if (variables[index - 1].VariableType != VariableType.Vector2)
                            {
                                contents += "\n[UnityHeader(\"Vector2s\")]";
                            }
                            contents += "\n[Networked]\npublic Vector2 " + variable.GetDisplayName() + " {get;set;}";
                            contents += "\nprivate FsmVector2 fsm" + variable.GetDisplayName() + ";\n";
                            break;
                        case VariableType.Vector3:
                            index = Array.IndexOf(variables, variable);
                            if (index == 0)
                            {
                                //add header
                                contents += "\n[UnityHeader(\"Vector3s\")]";
                            }
                            else if (variables[index - 1].VariableType != VariableType.Vector3)
                            {
                                contents += "\n[UnityHeader(\"Vector3s\")]";
                            }
                            contents += "\n[Networked]\npublic Vector3 " + variable.GetDisplayName() + " {get;set;}";
                            contents += "\nprivate FsmVector3 fsm" + variable.GetDisplayName() + ";\n";
                            break;
                        default:
                            Debug.LogError("Variable of type " + variable.VariableType + " from FSM: " + fsm + " can not be Networked.");
                            break;
                    }
                }
            }
            contents += "\n";


            #endregion

            #region This Section creates our Start() method
            //we need to create our start method that sets references to the FsmVariables

            contents += "\n\nprivate void Start()\n{\n";

            foreach (NamedVariable variable in variables)
            {
                if (variable.NetworkSync == true || variable.GetDisplayName().StartsWith("network"))
                {
                    switch (variable.VariableType)
                    {
                        //TODO: Come back to arrays
                        case VariableType.Array:
                            switch (variable.TypeConstraint)
                            {
                                case VariableType.Float:
                                    contents += "fsm" + variable.GetDisplayName() + " = fsmSource.FsmVariables.FindFsmArray(\"" + variable.GetDisplayName() + "\");\n";
                                    break;
                                case VariableType.Int:
                                    contents += "fsm" + variable.GetDisplayName() + " = fsmSource.FsmVariables.FindFsmArray(\"" + variable.GetDisplayName() + "\");\n";
                                    break;
                                case VariableType.Bool:
                                    contents += "fsm" + variable.GetDisplayName() + " = fsmSource.FsmVariables.FindFsmArray(\"" + variable.GetDisplayName() + "\");\n";
                                    break;
                                case VariableType.String:
                                    contents += "fsm" + variable.GetDisplayName() + " = fsmSource.FsmVariables.FindFsmArray(\"" + variable.GetDisplayName() + "\");\n";
                                    break;
                                case VariableType.Vector2:
                                    contents += "fsm" + variable.GetDisplayName() + " = fsmSource.FsmVariables.FindFsmArray(\"" + variable.GetDisplayName() + "\");\n";
                                    break;
                                case VariableType.Vector3:
                                    contents += "fsm" + variable.GetDisplayName() + " = fsmSource.FsmVariables.FindFsmArray(\"" + variable.GetDisplayName() + "\");\n";
                                    break;
                                case VariableType.Color:
                                    contents += "fsm" + variable.GetDisplayName() + " = fsmSource.FsmVariables.FindFsmArray(\"" + variable.GetDisplayName() + "\");\n";
                                    break;
                                case VariableType.Rect:
                                    contents += "fsm" + variable.GetDisplayName() + " = fsmSource.FsmVariables.FindFsmArray(\"" + variable.GetDisplayName() + "\");\n";
                                    break;
                                case VariableType.Quaternion:
                                    contents += "fsm" + variable.GetDisplayName() + " = fsmSource.FsmVariables.FindFsmArray(\"" + variable.GetDisplayName() + "\");\n";
                                    break;
                                case VariableType.Enum:
                                    contents += "fsm" + variable.GetDisplayName() + " = fsmSource.FsmVariables.FindFsmArray(\"" + variable.GetDisplayName() + "\");\n";
                                    break;
                                default:
                                    Debug.LogError("Array Variable of type " + variable.VariableType + " from FSM: " + fsm + " can not be Networked.");
                                    break;

                            }
                            break;
                        case VariableType.Bool:
                            contents += "fsm" + variable.GetDisplayName() + " = fsmSource.FsmVariables.FindFsmBool(\"" + variable.GetDisplayName() + "\");\n";
                            break;
                        case VariableType.Color:
                            contents += "fsm" + variable.GetDisplayName() + " = fsmSource.FsmVariables.FindFsmColor(\"" + variable.GetDisplayName() + "\");\n";
                            break;
                        case VariableType.Enum:
                            contents += "fsm" + variable.GetDisplayName() + " = fsmSource.FsmVariables.FindFsmEnum(\"" + variable.GetDisplayName() + "\");\n";
                            break;
                        case VariableType.Float:
                            contents += "fsm" + variable.GetDisplayName() + " = fsmSource.FsmVariables.FindFsmFloat(\"" + variable.GetDisplayName() + "\");\n";
                            break;
                        case VariableType.Int:
                            contents += "fsm" + variable.GetDisplayName() + " = fsmSource.FsmVariables.FindFsmInt(\"" + variable.GetDisplayName() + "\");\n";
                            break;
                        case VariableType.Quaternion:
                            contents += "fsm" + variable.GetDisplayName() + " = fsmSource.FsmVariables.FindFsmQuaternion(\"" + variable.GetDisplayName() + "\");\n";
                            break;
                        case VariableType.Rect:
                            contents += "fsm" + variable.GetDisplayName() + " = fsmSource.FsmVariables.FindFsmRect(\"" + variable.GetDisplayName() + "\");\n";
                            break;
                        case VariableType.String:
                            contents += "fsm" + variable.GetDisplayName() + " = fsmSource.FsmVariables.FindFsmString(\"" + variable.GetDisplayName() + "\");\n";
                            break;
                        case VariableType.Vector2:
                            contents += "fsm" + variable.GetDisplayName() + " = fsmSource.FsmVariables.FindFsmVector2(\"" + variable.GetDisplayName() + "\");\n";
                            break;
                        case VariableType.Vector3:
                            contents += "fsm" + variable.GetDisplayName() + " = fsmSource.FsmVariables.FindFsmVector3(\"" + variable.GetDisplayName() + "\");\n";
                            break;
                        default:
                            break;
                    }
                }
            }


            contents += "}";//to end the start method

            #endregion

            #region This Section Creates the Update() method

            contents += "\n\nprivate void Update()\n{\n";

            contents += "if(HasStateAuthority)\n{\n";

            foreach (NamedVariable variable in variables)
            {
                if (variable.NetworkSync == true || variable.GetDisplayName().StartsWith("network"))
                {
                    if (variable.VariableType == VariableType.Enum)
                    {
                        System.Type enumType = variable.ObjectType;
                        contents += variable.GetDisplayName() + " = " + "(" + enumType + ")" + "fsm" + variable.GetDisplayName() + ".Value;\n";
                    }
                    else if (variable.VariableType == VariableType.Array)
                    {

                        switch (variable.TypeConstraint)
                        {
                            case VariableType.Float:
                                contents += "for (int i = 0; i < " + "fsm" + variable.GetDisplayName() + ".Length; i++)\n";
                                contents += "{\n";
                                contents += variable.GetDisplayName() + ".Set(i, (float)fsm" + variable.GetDisplayName() + ".Get(i));\n";
                                contents += "}\n";
                                break;
                            case VariableType.Int:
                                contents += "for (int i = 0; i < " + "fsm" + variable.GetDisplayName() + ".Length; i++)\n";
                                contents += "{\n";
                                contents += variable.GetDisplayName() + ".Set(i, (int)fsm" + variable.GetDisplayName() + ".Get(i));\n";
                                contents += "}\n";
                                break;
                            case VariableType.Bool:
                                contents += "for (int i = 0; i < " + "fsm" + variable.GetDisplayName() + ".Length; i++)\n";
                                contents += "{\n";
                                contents += variable.GetDisplayName() + ".Set(i, (bool)fsm" + variable.GetDisplayName() + ".Get(i));\n";
                                contents += "}\n";
                                break;
                            case VariableType.String:
                                contents += "for (int i = 0; i < " + "fsm" + variable.GetDisplayName() + ".Length; i++)\n";
                                contents += "{\n";
                                contents += variable.GetDisplayName() + ".Set(i, (string)fsm" + variable.GetDisplayName() + ".Get(i));\n";
                                contents += "}\n";
                                break;
                            case VariableType.Vector2:
                                contents += "for (int i = 0; i < " + "fsm" + variable.GetDisplayName() + ".Length; i++)\n";
                                contents += "{\n";
                                contents += variable.GetDisplayName() + ".Set(i, (Vector2)fsm" + variable.GetDisplayName() + ".Get(i));\n";
                                contents += "}\n";
                                break;
                            case VariableType.Vector3:
                                contents += "for (int i = 0; i < " + "fsm" + variable.GetDisplayName() + ".Length; i++)\n";
                                contents += "{\n";
                                contents += variable.GetDisplayName() + ".Set(i, (Vector3)fsm" + variable.GetDisplayName() + ".Get(i));\n";
                                contents += "}\n";
                                break;
                            case VariableType.Color:
                                contents += "for (int i = 0; i < " + "fsm" + variable.GetDisplayName() + ".Length; i++)\n";
                                contents += "{\n";
                                contents += variable.GetDisplayName() + ".Set(i, (Color)fsm" + variable.GetDisplayName() + ".Get(i));\n";
                                contents += "}\n";
                                break;
                            case VariableType.Rect:
                                contents += "for (int i = 0; i < " + "fsm" + variable.GetDisplayName() + ".Length; i++)\n";
                                contents += "{\n";
                                contents += variable.GetDisplayName() + ".Set(i, (Rect)fsm" + variable.GetDisplayName() + ".Get(i));\n";
                                contents += "}\n";
                                break;
                            case VariableType.Quaternion:
                                contents += "for (int i = 0; i < " + "fsm" + variable.GetDisplayName() + ".Length; i++)\n";
                                contents += "{\n";
                                contents += variable.GetDisplayName() + ".Set(i, (Quaternion)fsm" + variable.GetDisplayName() + ".Get(i));\n";
                                contents += "}\n";
                                break;
                            case VariableType.Enum:
                                System.Type enumType = variable.ObjectType;
                                contents += "for (int i = 0; i < " + "fsm" + variable.GetDisplayName() + ".Length; i++)\n";
                                contents += "{\n";
                                contents += variable.GetDisplayName() + ".Set(i, (" + enumType + ")fsm" + variable.GetDisplayName() + ".Get(i));\n";
                                contents += "}\n";
                                break;
                            default:
                                Debug.LogError("Array Variable of type " + variable.VariableType + " from FSM: " + fsm + " can not be Networked.");
                                break;

                        }
                    }
                    else
                    {
                        contents += variable.GetDisplayName() + " = " + "fsm" + variable.GetDisplayName() + ".Value;\n";
                    }


                }

            }

            contents += "\n}";//closes the hasstateauthority statement

            contents += "else\n{\n";

            foreach (NamedVariable variable in variables)
            {
                if (variable.NetworkSync == true || variable.GetDisplayName().StartsWith("network"))
                {
                    if (variable.VariableType == VariableType.Array)
                    {

                        switch (variable.TypeConstraint)
                        {
                            case VariableType.Float:
                                contents += "fsm" + variable.GetDisplayName() + ".Resize(" + variable.GetDisplayName() + ".Length);\n";
                                contents += "for (int i = 0; i < " + variable.GetDisplayName() + ".Length; i++)\n";
                                contents += "{\n";
                                contents += "fsm" + variable.GetDisplayName() + ".Set(i, " + variable.GetDisplayName() + ".Get(i));\n";
                                contents += "}\n";
                                break;
                            case VariableType.Int:
                                contents += "fsm" + variable.GetDisplayName() + ".Resize(" + variable.GetDisplayName() + ".Length);\n";
                                contents += "for (int i = 0; i < " + variable.GetDisplayName() + ".Length; i++)\n";
                                contents += "{\n";
                                contents += "fsm" + variable.GetDisplayName() + ".Set(i, " + variable.GetDisplayName() + ".Get(i));\n";
                                contents += "}\n";
                                break;
                            case VariableType.Bool:
                                contents += "fsm" + variable.GetDisplayName() + ".Resize(" + variable.GetDisplayName() + ".Length);\n";
                                contents += "for (int i = 0; i < " + variable.GetDisplayName() + ".Length; i++)\n";
                                contents += "{\n";
                                contents += "fsm" + variable.GetDisplayName() + ".Set(i, " + variable.GetDisplayName() + ".Get(i));\n";
                                contents += "}\n";
                                break;
                            case VariableType.String:
                                contents += "fsm" + variable.GetDisplayName() + ".Resize(" + variable.GetDisplayName() + ".Length);\n";
                                contents += "for (int i = 0; i < " + variable.GetDisplayName() + ".Length; i++)\n";
                                contents += "{\n";
                                contents += "fsm" + variable.GetDisplayName() + ".Set(i, " + variable.GetDisplayName() + ".Get(i));\n";
                                contents += "}\n";
                                break;
                            case VariableType.Vector2:
                                contents += "fsm" + variable.GetDisplayName() + ".Resize(" + variable.GetDisplayName() + ".Length);\n";
                                contents += "for (int i = 0; i < " + variable.GetDisplayName() + ".Length; i++)\n";
                                contents += "{\n";
                                contents += "fsm" + variable.GetDisplayName() + ".Set(i, " + variable.GetDisplayName() + ".Get(i));\n";
                                contents += "}\n";
                                break;
                            case VariableType.Vector3:
                                contents += "fsm" + variable.GetDisplayName() + ".Resize(" + variable.GetDisplayName() + ".Length);\n";
                                contents += "for (int i = 0; i < " + variable.GetDisplayName() + ".Length; i++)\n";
                                contents += "{\n";
                                contents += "fsm" + variable.GetDisplayName() + ".Set(i, " + variable.GetDisplayName() + ".Get(i));\n";
                                contents += "}\n";
                                break;
                            case VariableType.Color:
                                contents += "fsm" + variable.GetDisplayName() + ".Resize(" + variable.GetDisplayName() + ".Length);\n";
                                contents += "for (int i = 0; i < " + variable.GetDisplayName() + ".Length; i++)\n";
                                contents += "{\n";
                                contents += "fsm" + variable.GetDisplayName() + ".Set(i, " + variable.GetDisplayName() + ".Get(i));\n";
                                contents += "}\n";
                                break;
                            case VariableType.Rect:
                                contents += "fsm" + variable.GetDisplayName() + ".Resize(" + variable.GetDisplayName() + ".Length);\n";
                                contents += "for (int i = 0; i < " + variable.GetDisplayName() + ".Length; i++)\n";
                                contents += "{\n";
                                contents += "fsm" + variable.GetDisplayName() + ".Set(i, " + variable.GetDisplayName() + ".Get(i));\n";
                                contents += "}\n";
                                break;
                            case VariableType.Quaternion:
                                contents += "fsm" + variable.GetDisplayName() + ".Resize(" + variable.GetDisplayName() + ".Length);\n";
                                contents += "for (int i = 0; i < " + variable.GetDisplayName() + ".Length; i++)\n";
                                contents += "{\n";
                                contents += "fsm" + variable.GetDisplayName() + ".Set(i, " + variable.GetDisplayName() + ".Get(i));\n";
                                contents += "}\n";
                                break;
                            case VariableType.Enum:
                                contents += "fsm" + variable.GetDisplayName() + ".Resize(" + variable.GetDisplayName() + ".Length);\n";
                                contents += "for (int i = 0; i < " + variable.GetDisplayName() + ".Length; i++)\n";
                                contents += "{\n";
                                contents += "fsm" + variable.GetDisplayName() + ".Set(i, " + variable.GetDisplayName() + ".Get(i));\n";
                                contents += "}\n";
                                break;
                            default:
                                Debug.LogError("Array Variable of type " + variable.VariableType + " from FSM: " + fsm + " can not be Networked.");
                                break;

                        }
                    }
                    else
                    {
                        contents += "fsm" + variable.GetDisplayName() + ".Value = " + variable.GetDisplayName() + ";\n";
                    }


                }

            }

            contents += "\n}";//closes the else statement

            contents += "}";//to end the Update method

            contents += "}";//to end the entire class

            string newScriptPath = path + "/" + identifier + ".cs";
            File.WriteAllText(path + "/" + identifier + ".cs", contents);
            Array.Resize(ref scriptPaths, scriptPaths.Length + 1);
            scriptPaths.SetValue(newScriptPath, scriptPaths.Length - 1);
        }
        #endregion

        //OnStep1Completed();

        foreach (string path in scriptPaths)
            {
                AssetDatabase.ImportAsset(path);
            }

            Debug.Log("You may click the 'Step 2' button after Unity Compiles.");
        }

        /* private IEnumerator WaitForCompiling()
         {
             yield return new WaitUntil(() => EditorApplication.isCompiling);
             while (EditorApplication.isCompiling)
             {
                 yield return null; // Wait for the next frame
             }

             // Unity finished compiling
             Debug.Log("Unity finished compiling!");

             // Add your code here to execute after Unity finishes compiling

             AddComponents();
         }*/

        public void AddComponents()
        {
            Debug.Log("Adding Components");
            foreach (PlayMakerFSM fsm in fsmsToCheck)
            {
                #region This Section Creates a Name for the NetworkBehaviour
                string fsmName = Regex.Replace(fsm.FsmName, @"\s+", "");
                fsmName = Regex.Replace(fsmName, "[^a-zA-Z0-9]", "");
                char c = Convert.ToChar(fsmName[0]);

                if (Char.IsDigit(c))
                {
                    fsmName = "Z" + fsmName;
                }
                fsmName = fsmName.Substring(0, 1).ToUpper() + fsmName.Substring(1);
                string identifier = fsmName + gameObject.GetInstanceID().ToString();
                identifier = identifier.Replace("-", ""); // Remove hyphens
            #endregion


            //yield return new WaitUntil(() => System.Type.GetType(identifier) != null);


            System.Type componentType = System.Type.GetType(identifier);
                Component component = gameObject.GetComponent(componentType);
                if (component == null)
                {
                    component = gameObject.AddComponent(componentType);
                }
                System.Reflection.FieldInfo field = component.GetType().GetField("fsmSource");
                if (field != null)
                {
                    field.SetValue(component, fsm);
                }
            }

            if (GetComponent<NetworkObject>() == null)
            {
                gameObject.AddComponent<NetworkObject>();
            }
            Debug.Log("Finished Setting Up Network Sync Variables.");
            DestroyImmediate(this);
        }

        private int GetCapacity(string originalString)
        {
            int extractedInt;
            string lastThreeCharacters = originalString.Substring(originalString.Length - 3);

            if (int.TryParse(lastThreeCharacters, out extractedInt))
            {
                return extractedInt;
            }
            else
            {
                string lastTwoCharacters = originalString.Substring(originalString.Length - 2);
                if (int.TryParse(lastTwoCharacters, out extractedInt))
                {
                    return extractedInt;
                }
                else
                {
                    string lastCharacter = originalString.Substring(originalString.Length - 1);
                    if (int.TryParse(lastCharacter, out extractedInt))
                    {
                        return extractedInt;
                    }
                    else
                    {
                        return 16;
                    }
                }
            }

        }
    }


    



    class NamedVariableComparer : IComparer<NamedVariable>
    {
        public int Compare(NamedVariable x, NamedVariable y)
        {
            // First compare by type
            int typeComparison = x.GetType().Name.CompareTo(y.GetType().Name);
            if (typeComparison != 0)
            {
                return typeComparison;
            }

            // Then compare by name
            return x.GetDisplayName().CompareTo(y.GetDisplayName());
        }
    }

#endif