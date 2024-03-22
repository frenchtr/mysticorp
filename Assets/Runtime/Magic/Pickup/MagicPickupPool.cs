using MystiCorp.Runtime.Common.Pooling;
using UnityEngine;

namespace MystiCorp.Runtime.Magic.Pickup
{
    [CreateAssetMenu(menuName = "Services/Pools/Magic Pickup Pool")]
    public class MagicPickupPool : ObjectPoolService
    {
        public void Spawn(MagicPickupSpawnArgs args)
        {
            var pickup = GetObject().GetComponent<MagicPickup>();

            pickup.PickedUp += Despawn;
            pickup.Spawn(args);

            pickup.gameObject.SetActive(true);
        }

        public bool TryGetClosestPickup(Vector2 position, out GameObject closest)
        {
            closest = null;
            float closestSqrDistance = Mathf.Infinity;

            foreach (var pickup in ActiveObjects.ToArray())
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
    }
}
