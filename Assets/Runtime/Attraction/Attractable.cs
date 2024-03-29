using UnityEngine;

namespace MystiCorp.Runtime.Attraction
{
    public class Attractable : MonoBehaviour
    {
        [SerializeField]
        private new Rigidbody2D rigidbody;

        public void AddVelocity(Vector2 velocity)
        {
            rigidbody.velocity += velocity;
        }

        public void AttractTo(Vector2 target, float speed)
        {
            rigidbody.velocity = (target - (Vector2)transform.position).normalized * speed;
        }
    }
}
