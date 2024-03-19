using MystiCorp.Runtime.Common.ScriptableEvents;
using MystiCorp.Runtime.Damage;
using MystiCorp.Runtime.Targeting;
using UnityEngine;

namespace MystiCorp.Runtime.Machines
{
    [RequireComponent(typeof(TargetingBehaviour))]
    public class OnCycledShootAtCurrentTargetBehaviour : MonoBehaviour
    {
        [SerializeField]
        private float damageAmount = 1f;
        [SerializeField]
        private Transform shootOrigin;
        [SerializeField]
        private ContactFilter2D filter;
        [Header("Components")]
        [SerializeField]
        private TargetingBehaviour targetingBehaviour;
        [Header("Events")]
        [SerializeField]
        private GameObjectEvent cycledEvent;

        private void OnEnable()
        {
            cycledEvent.Raised += OnCycled;
        }

        private void OnDisable()
        {
            cycledEvent.Raised -= OnCycled;
        }

        private void OnCycled(GameObject obj)
        {
            if (obj != gameObject)
            {
                return;
            }

            var currentTarget = targetingBehaviour.CurrentTarget;

            if (currentTarget == null)
            {
                return;
            }
            
            ShootAt(currentTarget);
        }

        private void ShootAt(GameObject target)
        {
            var receiver = target.GetComponent<DamageReceiver>();

            if (receiver == null)
            {
                return;
            }
            
            receiver.TakeDamage(damageAmount);
        }
    }
}
