using MystiCorp.Runtime.Damage;
using MystiCorp.Runtime.Magic.Pickup;
using UnityEngine;
using MystiCorp.Runtime.Common.ScriptableVariables;

namespace MystiCorp.Runtime.Character.Critters
{
    public class DropMagicOnDeath : MonoBehaviour
    {
        [SerializeField]
        private float magicValue;
        [SerializeField]
        private FloatVariable playerMagicAmount;
        [SerializeField]
        private CollectiblePool magicPickupPool;
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
            magicPickupPool.Spawn(transform.position, OnCollected);
        }

        private void OnCollected()
        {
            playerMagicAmount.Value += magicValue;
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
