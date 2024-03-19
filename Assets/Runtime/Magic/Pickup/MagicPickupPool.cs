using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace MystiCorp.Runtime.Magic.Pickup
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
            if (this.pool == null) this.InitializePool();

            var pickup = this.pool.Get();

            pickup.transform.position = position;
            pickup.Value = value;

            return pickup;
        }

        public bool TryGetClosestPickup(Vector2 position, out MagicPickup closest)
        {
            closest = null;
            float closestSqrDistance = Mathf.Infinity;

            foreach (var pickup in this.activePickups)
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
            this.poolParent = new GameObject("Magic Pickup Pool").transform;

            this.activePickups = new();

            this.pool = new(createFunc: this.CreatePickup, actionOnGet: this.GetPickup, actionOnRelease: this.ReleasePickup);
        }

        private MagicPickup CreatePickup()
        {
            return Instantiate(this.pickupPrefab, this.poolParent);
        }

        private void GetPickup(MagicPickup pickup)
        {
            this.activePickups.Add(pickup);
            pickup.gameObject.SetActive(true);
        }

        private void ReleasePickup(MagicPickup pickup)
        {
            this.activePickups.Remove(pickup);
            pickup.gameObject.SetActive(false);
        }
    }
}
