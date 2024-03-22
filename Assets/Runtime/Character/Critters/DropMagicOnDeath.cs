using MystiCorp.Runtime.Damage;
using MystiCorp.Runtime.Magic.Pickup;
using UnityEngine;

namespace MystiCorp.Runtime.Character.Critters
{
    public class DropMagicOnDeath : MonoBehaviour
    {
        [SerializeField]
        private float magicValue;
        [SerializeField]
        private MagicPickupPool magicPickupPool;
        private CharacterHealth health;

        private void Awake()
        {
            GetDependencies();
            
            health.Death += OnDeath;
        }

        private void Reset()
        {
            GetDependencies();
        }

        private void OnDeath()
        {
            magicPickupPool.Spawn(new()
            {
                value = magicValue,
                position = transform.position
            });
        }

        private void GetDependencies()
        {
            if (health == null)
            {
                health = GetComponent<CharacterHealth>();
            }
        }
    }
}
