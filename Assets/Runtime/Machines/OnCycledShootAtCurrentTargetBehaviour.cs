using MystiCorp.Runtime.Damage;
using MystiCorp.Runtime.Bullets;
using MystiCorp.Runtime.Targeting;
using UnityEngine;
using OliverBeebe.UnityUtilities.Runtime;

namespace MystiCorp.Runtime.Machines
{
    [RequireComponent(typeof(TargetingBehaviour))]
    [RequireComponent(typeof(MagnitudeBehaviour))]
    public class OnCycledShootAtCurrentTargetBehaviour : OnCycledBehaviourBase
    {
        [SerializeField]
        private Transform shootOrigin;
        [SerializeField]
        private BulletPool bulletPool;
        [SerializeField]
        private SoundEffect shootSound;

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

        protected override void OnCycled()
        {
            var currentTarget = targetingBehaviour.CurrentTarget;

            if (currentTarget != null
                && currentTarget.TryGetComponent(out DamageReceiver receiver))
            {
                ShootAt(receiver);
            } 
        }

        private void ShootAt(DamageReceiver receiver)
        {
            var amount = magnitudeBehaviour.Magnitude;
            receiver.TakeDamage(amount);

            shootSound.Play(this);
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
    }
}
