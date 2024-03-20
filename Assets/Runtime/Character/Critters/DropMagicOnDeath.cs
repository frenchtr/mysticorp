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
        private CharacterHealth health;
        [SerializeField]
        private MagicPickupPool magicPickupPool;

        private void Awake()
        {
            health.Death += OnDeath;
        }

        private void OnDeath()
        {
            magicPickupPool.SpawnPickup(magicValue, transform.position);
        }
    }
}
