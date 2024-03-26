using System;
using UnityEngine;

namespace MystiCorp.Runtime.Attraction
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Attractable : MonoBehaviour
    {
        [SerializeField]
        private new Rigidbody2D rigidbody;
        
        private void Awake()
        {
            GetDependencies();
        }

        private void Reset()
        {
            GetDependencies();
        }

        private void GetDependencies()
        {
            if (rigidbody == null)
            {
                rigidbody = GetComponent<Rigidbody2D>();
            }
        }

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
