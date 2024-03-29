using System;
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
        private DamageTextPool damageTextPool;

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

        public event Action<ValueChangedArgs<float>> HealthChanged;
        public event Action Death;

        private void OnEnable()
        {
            damagedEvent.Raised += OnDamagedEvent;
        }

        private void OnDisable()
        {
            damagedEvent.Raised -= OnDamagedEvent;
        }

        private void Start()
        {
            Health = maxHealth;
        }

        private void OnDamagedEvent(DamageArgs args)
        {
            if (args.Receiver.gameObject != gameObject) return;

            Health = Mathf.MoveTowards(Health, 0, args.Amount);

            damageTextPool.Spawn(new(args.Amount, transform.position));

            if (Health == 0)
            {
                Death?.Invoke();
                if (destroyOnDeath) Destroy(gameObject);
            }
        }
    }
}
