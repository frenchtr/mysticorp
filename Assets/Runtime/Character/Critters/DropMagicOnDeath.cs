using MystiCorp.Runtime.Damage;
using UnityEngine;
using MystiCorp.Runtime.Common.ScriptableVariables;
using MystiCorp.Runtime.Collectibles;

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
        [SerializeField]
        private CharacterHealth health;

        private void Awake()
        {            
            health.Death += OnDeath;
        }

        private void OnDeath()
        {
            int drops = Random.Range(0, maxDrops) + 1;
            var weights = new float[drops];
            float total = 0;

            // generate random weights for each magic drop
            for (int i = 0; i < drops; i++)
            {
                float value = Random.value;
                weights[i] = value;
                total += value;
            }

            foreach (var weight in weights)
            {
                float percent = weight / total;
                SpawnMagic(percent);
            }
        }

        private void SpawnMagic(float percent)
        {
            float dropDist = Random.Range(0, dropRange);
            Vector2 dropOffset = Random.insideUnitCircle * dropDist;
            Vector2 dropPosition = (Vector2)transform.position + dropOffset;

            float value = magicValue * percent;
            void OnCollected() => playerMagicAmount.Value += value;

            var magicPickup = magicPickupPool.Spawn(new(dropPosition, OnCollected));

            float size = Mathf.Lerp(minMagicSize, maxMagicSize, percent);
            magicPickup.transform.localScale = Vector3.one * size;
        }
    }
}
