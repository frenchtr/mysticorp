using UnityEngine;

namespace MystiCorp.Runtime.Character
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField]
        private float moveSpeed;
        [SerializeField]
        private new Rigidbody2D rigidbody;

        private Vector2 targetPosition;
        private bool moving;

        public void MoveTo(Vector2 position)
        {
            targetPosition = position;
            moving = true;
        }

        public void Stop()
        {
            moving = false;
        }

        private void Update()
        {
            Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;

            if (moving) rigidbody.velocity = direction * moveSpeed;
        }
    }
}
