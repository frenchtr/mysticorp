using UnityEngine;

namespace MystiCorp.Runtime.Damage
{
    public class DamageLogger : MonoBehaviour
    {
        [SerializeField]
        private DamageArgsEvent damagedEvent;

        private void OnEnable()
        {
            damagedEvent.Raised += OnDamaged;
        }

        private void OnDisable()
        {
            damagedEvent.Raised -= OnDamaged;
        }

        private void OnDamaged(DamageArgs args)
        {
            Debug.Log($"{args.Receiver} took {args.Amount} damage!");
        }
    }
}
