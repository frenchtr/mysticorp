using MystiCorp.Runtime.Damage;
using MystiCorp.Runtime.Bullets;
using MystiCorp.Runtime.Targeting;
using UnityEngine;
using OliverBeebe.UnityUtilities.Runtime;

namespace MystiCorp.Runtime.Machines
{
    public class OnCycledShootAtCurrentTargetBehaviour : OnCycledBehaviourBase
    {
        [SerializeField]
        private Transform shootOrigin;
        [SerializeField]
        private BulletPool bulletPool;
        [SerializeField]
        private SoundEffect shootSound;

        [Header("Dependencies")]
        [SerializeField]
        private TargetingBehaviour targetingBehaviour;
        [SerializeField]
        private MagnitudeBehaviour magnitudeBehaviour;

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
            bulletPool.Spawn(new(shootOrigin.position, receiver.transform.position));
        }
    }
}
