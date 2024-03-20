using MystiCorp.Runtime.Magic.Pickup;
using UnityEngine;

namespace MystiCorp.Runtime.Character.Hero
{
    public class HeroBrain : MonoBehaviour
    {
        [SerializeField]
        private MagicPickupPool pickupPool;
        private CharacterMovement movement;
        private MagicPickerUpper pickerUpper;

        private void Awake()
        {
            GetDependencies();
        }

        private void Reset()
        {
            GetDependencies();
        }

        private void Update()
        {
            pickerUpper.Pickup(10);

            if (pickupPool.TryGetClosestPickup(transform.position, out var closestPickup))
            {
                movement.MoveTo(closestPickup.transform.position);
            }
        }

        private void GetDependencies()
        {
            if (movement == null)
            {
                movement = GetComponent<CharacterMovement>();
            }

            if (pickerUpper == null)
            {
                pickerUpper = GetComponent<MagicPickerUpper>();
            }
        }
    }
}
