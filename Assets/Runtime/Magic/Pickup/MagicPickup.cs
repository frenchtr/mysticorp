using UnityEngine;

namespace MystiCorp.Runtime.Magic.Pickup
{
    public class MagicPickup : MonoBehaviour
    {
        [SerializeField]
        private float value;

        public event System.Action<GameObject> PickedUp;

        public void Spawn(MagicPickupSpawnArgs args)
        {
            value = args.value;
            transform.position = args.position;
        }

        public float Pickup()
        {
            PickedUp?.Invoke(gameObject);
            PickedUp = null;

            return value;
        }
    }
}
