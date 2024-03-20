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
        private DamageReceiver damageReceiver;
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

        public event Action<ValueChangedArgs<float>> HealthChanged;
        public event Action Death;

        private void OnEnable()
        {
            GetDependencies();
            
            damagedEvent.Raised += OnDamagedEvent;
        }

<<<<<<< HEAD
        private void OnDisable()
        {
            damagedEvent.Raised -= OnDamagedEvent;
=======
        private void Reset()
        {
            GetDependencies();
>>>>>>> 4f59ca93255b36c583830b3b90b40f3849136253
        }

        private void Start()
        {
            Health = maxHealth;
        }

        private void GetDependencies()
        {
            
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
