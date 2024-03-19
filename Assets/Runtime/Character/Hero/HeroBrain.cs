using MystiCorp.Runtime.Magic.Pickup;
using UnityEngine;

namespace MystiCorp.Runtime.Character.Hero
{
    public class HeroBrain : MonoBehaviour
    {
        [SerializeField]
        private CharacterMovement movement;
        [SerializeField]
        private MagicPickerUpper pickerUpper;
        [SerializeField]
        private MagicPickupPool pickupPool;

        private void Update()
        {
            this.pickerUpper.Pickup(10);

            if (this.pickupPool.TryGetClosestPickup(this.transform.position, out var closestPickup))
            {
                this.movement.MoveTo(closestPickup.transform.position);
            }
        }
    }
}
