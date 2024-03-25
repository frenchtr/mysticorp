using MystiCorp.Runtime.Damage;
using MystiCorp.Runtime.Magic.Pickup;
using UnityEngine;
using MystiCorp.Runtime.Common.ScriptableVariables;
using System.Linq;

namespace MystiCorp.Runtime.Character.Critters
{
    public class DropMagicOnDeath : MonoBehaviour
    {
        [SerializeField]
        private float magicValue;
        [SerializeField]
        private float minMagicSize, maxMagicSize;
        [SerializeField]
        private int maxDrops;
        [SerializeField]
        private float dropRange;
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
            int drops = Random.Range(0, maxDrops) + 1;
            var weights = new float[drops];

            for (int i = 0; i < drops; i++)
            {
                weights[i] = Random.value;
            }

            float total = weights.Sum();

            for (int i = 0; i < drops; i++)
            {
                weights[i] /= total;
            }

            float real = 0;

            foreach (var weight in weights)
            {
                SpawnMagic(magicValue * weight);
                real += magicValue * weight;
            }
        }

        private void SpawnMagic(float percent)
        {
            float dropDist = Random.Range(0, dropRange);
            float size = Mathf.Lerp(minMagicSize, maxMagicSize, percent);
            Vector2 dropOffset = Random.insideUnitCircle * dropDist;

            var magic = magicPickupPool.Spawn((Vector2)transform.position + dropOffset, OnCollected);

            magic.transform.localScale = Vector3.one * size;

            void OnCollected() => playerMagicAmount.Value += magicValue * percent;
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
