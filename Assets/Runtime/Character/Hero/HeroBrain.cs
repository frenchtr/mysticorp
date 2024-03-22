using MystiCorp.Runtime.Magic.Pickup;
using UnityEngine;
using MystiCorp.Runtime.Attraction;

namespace MystiCorp.Runtime.Character.Hero
{
    public class HeroBrain : MonoBehaviour
    {
        [SerializeField]
        private MagicPickupPool pickupPool;
        [SerializeField]
        private CharacterMovement movement;
        [SerializeField]
        private MagicCollector pickerUpper;
        [SerializeField]
        private Attractor attractor;

        private void Update()
        {
            pickerUpper.Pickup(10);

            attractor.AttractAllNearby();

            if (pickupPool.TryGetClosestPickup(transform.position, out var closestPickup))
            {
                movement.MoveTo(closestPickup.transform.position);
            }
        }
    }
}
