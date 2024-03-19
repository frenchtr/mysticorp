using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MystiCorp.Runtime
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
            pickerUpper.Pickup(10);

            if (pickupPool.TryGetClosestPickup(transform.position, out var closestPickup))
            {
                movement.MoveTo(closestPickup.transform.position);
            }
        }
    }
}