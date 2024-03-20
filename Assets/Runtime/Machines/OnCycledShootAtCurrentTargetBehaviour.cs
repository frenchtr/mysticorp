using System.Collections;
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
        private Transform shootOrigin;
        [SerializeField]
        private LineRenderer bullet;
        [SerializeField]
        private float duration = 0.15f;
        [Header("Components")]
        [SerializeField]
        private TargetingBehaviour targetingBehaviour;
        [SerializeField]
        private CycleBehaviour cycleBehaviour;
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

            var amount = cycleBehaviour.Magnitude;
            receiver.TakeDamage(amount);
            
            // Show the bullet
            bullet.positionCount = 2;
            bullet.SetPosition(0, shootOrigin.position);
            bullet.SetPosition(1, target.transform.position);
            bullet.gameObject.SetActive(true);
            StartCoroutine(HideBulletAfterSeconds(duration));
        }

        private IEnumerator HideBulletAfterSeconds(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            bullet.gameObject.SetActive(false);
        }
    }
}
