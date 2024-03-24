using MystiCorp.Runtime.Common.ScriptableEvents;
using MystiCorp.Runtime.Damage;
using MystiCorp.Runtime.Bullets;
using MystiCorp.Runtime.Targeting;
using UnityEngine;

namespace MystiCorp.Runtime.Machines
{
    [RequireComponent(typeof(CycleBehaviour))]
    [RequireComponent(typeof(TargetingBehaviour))]
    [RequireComponent(typeof(MagnitudeBehaviour))]
    public class OnCycledShootAtCurrentTargetBehaviour : MonoBehaviour
    {
        [SerializeField]
        private Transform shootOrigin;
        [SerializeField]
        private BulletPool bulletPool;
        [Header("Events")]
        [SerializeField]
        private GameObjectEvent cycledEvent;
        private TargetingBehaviour targetingBehaviour;
        private MagnitudeBehaviour magnitudeBehaviour;

        private void Awake()
        {
            GetDependencies();
        }

        private void Reset()
        {
            GetDependencies();
        }

        private void OnEnable()
        {
            cycledEvent.Raised += OnCycled;
        }

        private void OnDisable()
        {
            cycledEvent.Raised -= OnCycled;
        }

        private void ShootAt(GameObject target)
        {
            var receiver = target.GetComponent<DamageReceiver>();

            if (receiver == null)
            {
                return;
            }

            var amount = magnitudeBehaviour.Magnitude;
            receiver.TakeDamage(amount);
            
            bulletPool.Spawn(shootOrigin.position, receiver.transform.position);
        }

        private void GetDependencies()
        {
            if (magnitudeBehaviour == null)
            {
                magnitudeBehaviour = GetComponent<MagnitudeBehaviour>();
            }

            if (targetingBehaviour == null)
            {
                targetingBehaviour = GetComponent<TargetingBehaviour>();
            }
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
    }
}
