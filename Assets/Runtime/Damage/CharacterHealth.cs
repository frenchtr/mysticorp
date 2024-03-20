using MystiCorp.Runtime.Common;
using UnityEngine;

namespace MystiCorp.Runtime.Damage
{
    public class CharacterHealth : MonoBehaviour
    {
        [SerializeField]
        private float maxHealth;
        [SerializeField]
        private bool destroyOnDeath;
        [SerializeField]
        private DamageArgsEvent damagedEvent;

        [SerializeField]
        [InspectorName("Current Health")]
        private float health;

        public float Health
        {
            get => health;
            set
            {
                var args = new ValueChangedArgs<float>
                {
                    From = health,
                    To = value,
                };

                health = value;

                HealthChanged?.Invoke(args);
            }
        }

        public event System.Action<ValueChangedArgs<float>> HealthChanged;
        public event System.Action Death;

        private void Awake()
        {
            damagedEvent.Raised += OnDamagedEvent;
        }

        private void Start()
        {
            Health = maxHealth;
        }

        private void OnDamagedEvent(DamageArgs args)
        {
            if (args.Receiver.gameObject != gameObject) return;

            Health = Mathf.MoveTowards(Health, 0, args.Amount);

            if (Health == 0)
            {
                Death?.Invoke();
                if (destroyOnDeath) Destroy(gameObject);
            }
        }
    }
}
