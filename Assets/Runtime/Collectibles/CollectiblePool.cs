using MystiCorp.Runtime.Common.Pooling;
using UnityEngine;

namespace MystiCorp.Runtime.Magic.Pickup
{
    [CreateAssetMenu(menuName = "Services/Pools/Collectible Pool")]
    public class CollectiblePool : ObjectPoolService
    {
        private void OnValidate()
        {
            if (prefab != null && !prefab.TryGetComponent(out Collectible collectible))
            {
                prefab = null;
                Debug.LogError("Prefab must have collectible component!");
            }
        }

        public GameObject Spawn(Vector2 position, System.Action onCollected)
        {
            var collectible = GetObject();

            collectible.transform.position = position;
            collectible.SetActive(true);

            collectible.GetComponent<Collectible>().Collected += () =>
            {
                Despawn(collectible);
                onCollected.Invoke();
            };

            return collectible;
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
                    closest = collectible;
                }
            }

            return closest != null;
        }
    }
}
