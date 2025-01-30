using Fusion;
using HutongGames.PlayMaker;
using UnityEngine;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;

namespace GooglyEyesGames.PlayMaker.Fusion
{

	[ActionCategory("Fusion")]
    [Tooltip("You can't destroy a NetworkObject. You have to Despawn it.")]
    public class FusionDespawnNetworkObject : FsmStateAction
	{
        public FsmOwnerDefault gameObject;

        public override void Reset()
        {
            gameObject = null;
        }
        public override void OnEnter()
        {

            var go = Fsm.GetOwnerDefaultTarget(gameObject);

            if (go == null)
            {
                Debug.LogWarning("Attempted to Depawn a GameObject from a null variable!");
            }
            else
            {
                if (go.GetComponent<NetworkObject>())
                {
                    NetworkObject no = go.GetComponent<NetworkObject>();
                    if (no.HasStateAuthority)
                    {
                        PlaymakerFusionNetworkRunner.PFNR._runner.Despawn(no);
                    }
                    else
                    {
                        Debug.LogWarning("You attempted to Despawn a NetworkObject that you don't have StateAuthority over!");
                    }
                }
                else
                {
                    Debug.LogWarning("You attempted to Despawn a GameObject without a NetworkObject component!");
                }
            }
            Finish();
        }
    }

}
