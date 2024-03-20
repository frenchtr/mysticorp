using UnityEngine;

namespace MystiCorp.Runtime.Magic.Pickup
{
    public class MagicPickup : MonoBehaviour
    {
        private MagicPickupPool pool;
        private float value;

        public void Spawn(float value, Vector2 position, MagicPickupPool pool)
        {
            this.value = value;
            transform.position = position;
            this.pool = pool;
        }

        public float Pickup()
        {
            pool.DespawnPickup(this);
            return value;
        }
    }
}
