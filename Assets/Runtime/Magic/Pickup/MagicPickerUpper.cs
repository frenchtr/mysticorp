using System.Collections.Generic;
using MystiCorp.Runtime.Common.ScriptableVariables;
using UnityEngine;

namespace MystiCorp.Runtime.Magic.Pickup
{
    public class MagicPickerUpper : MonoBehaviour
    {
        [SerializeField]
        private FloatVariable magicAmount;

        private List<MagicPickup> touchingPickups;

        private void Awake()
        {
            touchingPickups = new();
        }

        public void Pickup(int count)
        {
            for (int i = 0; i < count && i < touchingPickups.Count; i++)
            {
                var pickup = touchingPickups[touchingPickups.Count - i - 1];

                magicAmount.Value += pickup.Pickup();

                touchingPickups.Remove(pickup);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out MagicPickup pickup) && !touchingPickups.Contains(pickup))
            {
                touchingPickups.Add(pickup);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out MagicPickup pickup) && touchingPickups.Contains(pickup))
            {
                touchingPickups.Remove(pickup);
            }
        }
    }
}
