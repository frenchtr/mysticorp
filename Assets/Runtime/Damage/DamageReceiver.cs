using UnityEngine;

namespace MystiCorp.Runtime.Damage
{
    public class DamageReceiver : MonoBehaviour
    {
        [Header("Events")]
        [SerializeField]
        private DamageArgsEvent damagedEvent;
        
        public void TakeDamage(float amount)
        {
            var args = new DamageArgs()
            {
                Receiver = this,
                Amount = amount,
            };
            
            damagedEvent.Raise(args);
        }
    }
}
