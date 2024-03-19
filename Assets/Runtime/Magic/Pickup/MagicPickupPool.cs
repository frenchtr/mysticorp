using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace MystiCorp.Runtime
{
    [CreateAssetMenu(menuName = "Services/Magic Pickups")]
    public class MagicPickupPool : ScriptableObject
    {
        [SerializeField]
        private MagicPickup pickupPrefab;

        private Transform poolParent;
        private ObjectPool<MagicPickup> pool;
        private List<MagicPickup> activePickups;

        public MagicPickup SpawnPickup(float value, Vector2 position)
        {
            if (pool == null) InitializePool();

            var pickup = pool.Get();

            pickup.transform.position = position;
            pickup.Value = value;

            return pickup;
        }

        public bool TryGetClosestPickup(Vector2 position, out MagicPickup closest)
        {
            closest = null;
            float closestSqrDistance = Mathf.Infinity;

            foreach (var pickup in activePickups)
            {
                float sqrDsistance = (position - (Vector2)pickup.transform.position).sqrMagnitude;

                if (sqrDsistance < closestSqrDistance)
                {
                    closestSqrDistance = sqrDsistance;
                    closest = pickup;
                }
            }

            return closest != null;
        }

        private void InitializePool()
        {
            poolParent = new GameObject("Magic Pickup Pool").transform;

            activePickups = new();

            pool = new(createFunc: CreatePickup, actionOnGet: GetPickup, actionOnRelease: ReleasePickup);
        }

        private MagicPickup CreatePickup()
        {
            return Instantiate(pickupPrefab, poolParent);
        }

        private void GetPickup(MagicPickup pickup)
        {
            activePickups.Add(pickup);
            pickup.gameObject.SetActive(true);
        }

        private void ReleasePickup(MagicPickup pickup)
        {
            activePickups.Remove(pickup);
            pickup.gameObject.SetActive(false);
        }
    }
}
