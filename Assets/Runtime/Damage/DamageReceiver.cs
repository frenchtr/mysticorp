using UnityEngine;

namespace MystiCorp.Runtime.Damage
{
    public class DamageReceiver : MonoBehaviour
    {
        [Header("Events")]
        [SerializeField]
        private DamageArgsEvent globalDamagedEvent;

        public event System.Action<DamageArgs> DamagedEvent;

        public void TakeDamage(float amount)
        {
            var args = new DamageArgs()
            {
                Receiver = this,
                Amount = amount,
            };

            DamagedEvent?.Invoke(args);
            globalDamagedEvent.Raise(args);
        }
    }
}
