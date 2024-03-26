using UnityEngine;
using MystiCorp.Runtime.Attraction;
using MystiCorp.Runtime.Collectibles;

namespace MystiCorp.Runtime.Character.Hero
{
    public class HeroBrain : MonoBehaviour
    {
        [SerializeField]
        private CollectiblePool pickupPool;
        [SerializeField]
        private CharacterMovement movement;
        [SerializeField]
        private Collector pickerUpper;
        [SerializeField]
        private Attractor attractor;

        private void Update()
        {
            pickerUpper.Collect(10);

            attractor.AttractAllNearby();

            if (pickupPool.TryGetClosestCollectible(transform.position, out var closestPickup))
            {
                movement.MoveTo(closestPickup.transform.position);
            }
        }
    }
}
