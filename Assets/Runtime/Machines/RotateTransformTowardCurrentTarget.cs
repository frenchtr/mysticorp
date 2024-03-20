using MystiCorp.Runtime.Targeting;
using UnityEngine;

namespace MystiCorp.Runtime.Machines
{
    [RequireComponent(typeof(TargetingBehaviour))]
    public class RotateTransformTowardCurrentTarget : MonoBehaviour
    {
        [SerializeField]
        private Transform transformToRotate;
        private TargetingBehaviour targetingBehaviour;

        private void Awake()
        {
            GetDependencies();
        }

        private void Reset()
        {
            GetDependencies();
        }

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

        private void GetDependencies()
        {
            if (targetingBehaviour == null)
            {
                targetingBehaviour = GetComponent<TargetingBehaviour>();
            }
        }
    }
}
