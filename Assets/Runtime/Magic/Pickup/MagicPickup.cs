using UnityEngine;

namespace MystiCorp.Runtime.Magic.Pickup
{
    public class MagicPickup : MonoBehaviour
    {
        private MagicPickupPool pool;
        private float value;

        public void Spawn(MagicPickupSpawnArgs args, MagicPickupPool pool)
        {
            value = args.value;
            transform.position = args.position;
            this.pool = pool;
        }

        public float Pickup()
        {
            pool.Despawn(gameObject);
            return value;
        }
    }
}
