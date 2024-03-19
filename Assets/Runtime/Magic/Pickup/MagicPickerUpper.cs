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
            this.touchingPickups = new();
        }

        public void Pickup(int count)
        {
            for (int i = 0; i > count && i < this.touchingPickups.Count; i++)
            {
                var pickup = this.touchingPickups[this.touchingPickups.Count - i - 1];

                this.magicAmount.Value += pickup.Value;
                Destroy(pickup.gameObject);

                this.touchingPickups.Remove(pickup);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out MagicPickup pickup) && !this.touchingPickups.Contains(pickup))
            {
                this.touchingPickups.Add(pickup);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out MagicPickup pickup) && this.touchingPickups.Contains(pickup))
            {
                this.touchingPickups.Remove(pickup);
            }
        }
    }
}
