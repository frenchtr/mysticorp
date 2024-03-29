using MystiCorp.Runtime.Targeting;
using UnityEngine;

namespace MystiCorp.Runtime.Machines
{
    public class RotateTransformTowardCurrentTarget : MonoBehaviour
    {
        [SerializeField]
        private Transform transformToRotate;
        [SerializeField]
        private TargetingBehaviour targetingBehaviour;

        private void Update()
        {
            if (transformToRotate == null || targetingBehaviour.CurrentTarget == null)
            {
                return;
            }

            var from = transform.position;
            var to = targetingBehaviour.CurrentTarget.transform.position;
            var direction = (to - from).normalized;
            
            transformToRotate.rotation = Quaternion.LookRotation(Vector3.forward, direction);
        }
    }
}
