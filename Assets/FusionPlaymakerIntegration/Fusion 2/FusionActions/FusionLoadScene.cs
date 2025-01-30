#if FUSION2
using Fusion;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;

namespace GooglyEyesGames.PlayMaker.Fusion
{

    [ActionCategory("Fusion")]
    [Tooltip("Only allowed to be called on the Host (usually Player 0). You should check first for SceneAuthority.")]
    public class FusionLoadScene : FsmStateAction
    {
        [Tooltip("The reference options of the Scene")]
        public GetSceneActionBase.SceneSimpleReferenceOptions sceneReference;

        [Tooltip("The name of the scene to load. The given sceneName can either be the last part of the path, without .unity extension or the full path still without the .unity extension")]
        public FsmString sceneByName;

        [Tooltip("The index of the scene to load.")]
        public FsmInt sceneAtIndex;

        private SceneRef sceneRef;

        [Tooltip("Allows you to specify whether or not to load the scene additively. See LoadSceneMode Unity doc for more information about the options.")]
        [ObjectType(typeof(LoadSceneMode))]
        public FsmEnum loadSceneMode;


        public override void Reset()
        {
            sceneByName = null;
            sceneAtIndex = null;
        }
        public override void OnEnter()
        {
            if (sceneReference == GetSceneActionBase.SceneSimpleReferenceOptions.SceneAtIndex)
            {
                sceneRef = SceneRef.FromIndex(sceneAtIndex.Value);
            }
            else
            {
                //This is where it isn't working
                int sceneIndex = GetSceneBuildIndex(sceneByName.Value);
                sceneRef = SceneRef.FromIndex(sceneIndex);
            }
            PlaymakerFusionNetworkRunner.PFNR._runner.LoadScene(sceneRef, (LoadSceneMode)loadSceneMode.Value);

            Finish();
        }

        private int GetSceneBuildIndex(string sceneName)
        {
            for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
            {
                string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
                string sceneNameInBuild = System.IO.Path.GetFileNameWithoutExtension(scenePath);
                if (sceneNameInBuild == sceneName)
                {
                    return i;
                }
            }

            return -1;
        }

    }
}
#endif
