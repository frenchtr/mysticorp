using UnityEngine;
using MystiCorp.Runtime.Common.Pooling;

namespace MystiCorp.Runtime.Portal
{
    [CreateAssetMenu(menuName = "Scriptables/Pools/Critter")]
    public class CritterPool : ObjectPoolService
    {
        [SerializeField]
        private int firstPortalLevel;
        [SerializeField]
        private float baseCrittersPerSecond;
        [SerializeField]
        private float scaleValue;

        private float numToSpawn = 0;

        public void UpdateSpawner(int level, Transform spawnpoint)
        {
            float spawnRate = CalculateSpawnRateAtLevel(level) * Time.deltaTime;

            numToSpawn += spawnRate;

            int count = Mathf.FloorToInt(numToSpawn);

            numToSpawn -= count;

            for (int i = 0; i < count; i++)
            {
                Spawn(spawnpoint);
            }
        }

        private void Spawn(Transform spawnPoint)
        {
            var critter = Spawn();

            critter.transform.position = spawnPoint.position;
        }

        private float CalculateSpawnRateAtLevel(int level) => level >= firstPortalLevel
            ? baseCrittersPerSecond * Mathf.Pow(scaleValue, level - firstPortalLevel)
            : 0;
    }
}
