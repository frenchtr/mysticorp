using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MystiCorp.Runtime.Magic.Pickup;

namespace MystiCorp.Runtime
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
