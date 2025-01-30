using Fusion;
using UnityEngine;
using HutongGames.PlayMaker;

namespace GooglyEyesGames.PlayMaker.Fusion
{

    [ActionCategory("Fusion")]
    public class FusionSpawnNetworkObject : FsmStateAction
    {
        [RequiredField]
        public FsmGameObject prefabToSpawn;
        public FsmVector3 spawnPosition;
        public FsmVector3 spawnRotation;

        private PlaymakerFusionNetworkRunner pfnr;
        private NetworkRunner runner;
        private PlayerRef player;

        [UIHint(UIHint.Variable)]
        public FsmGameObject spawnedGameObject;

        public FsmGameObject parent;
        public bool matchParentPosRot = false;
        public bool setAsLocalPlayerObject = false;

        public override void Reset()
        {
            prefabToSpawn = null;
            spawnPosition = null;
        }
        public override void OnEnter()
        {
            pfnr = PlaymakerFusionNetworkRunner.PFNR;
            runner = pfnr._runner;
            player = runner.LocalPlayer;

            Vector3 _rotation = Vector3.zero;
            Quaternion _quatRotation = Quaternion.identity;

            if (spawnRotation != null)
            {
                _rotation = spawnRotation.Value;
                _quatRotation = Quaternion.Euler(_rotation);
            }
            else
            {
                _quatRotation = Quaternion.identity;
            }


            NetworkObject networkPlayerObject = runner.Spawn(prefabToSpawn.Value, spawnPosition.Value, _quatRotation, player);
            spawnedGameObject.Value = networkPlayerObject.gameObject;
            if (parent.Value != null)
            {
                spawnedGameObject.Value.transform.parent = parent.Value.transform;

                if (matchParentPosRot)
                {
                    spawnedGameObject.Value.transform.localPosition = Vector3.zero;
                    spawnedGameObject.Value.transform.localEulerAngles = Vector3.zero;
                }


            }

            if (setAsLocalPlayerObject)
            {
                runner.SetPlayerObject(pfnr._runner.LocalPlayer, networkPlayerObject);


            }

            Finish();
        }

    }

}
