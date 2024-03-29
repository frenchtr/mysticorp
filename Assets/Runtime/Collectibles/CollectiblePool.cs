using MystiCorp.Runtime.Common.Pooling;
using UnityEngine;
using System;

namespace MystiCorp.Runtime.Collectibles
{
    public readonly struct CollectibleSpawnArgs
    {
        public CollectibleSpawnArgs(Vector2 position, Action actionOnCollected)
            => (this.position, this.actionOnCollected) = (position, actionOnCollected);

        public readonly Vector2 position;
        public readonly Action actionOnCollected;
    }

    [CreateAssetMenu(menuName = "Scriptables/Pools/Collectible")]
    public class CollectiblePool : ObjectPoolService
    {
        public GameObject Spawn(CollectibleSpawnArgs spawnArgs)
        {
            var collectible = Spawn();

            collectible.transform.position = spawnArgs.position;
            collectible.ReturnToPool += spawnArgs.actionOnCollected;

            collectible.gameObject.SetActive(true);

            return collectible.gameObject;
        }

        public bool TryGetClosestCollectible(Vector2 position, out GameObject closest)
        {
            closest = null;
            float closestSqrDistance = Mathf.Infinity;

            foreach (var collectible in ActiveObjects.ToArray())
            {
                float sqrDsistance = (position - (Vector2)collectible.transform.position).sqrMagnitude;

                if (sqrDsistance < closestSqrDistance)
                {
                    closestSqrDistance = sqrDsistance;
                    closest = collectible.gameObject;
                }
            }

            return closest != null;
        }
    }
}
