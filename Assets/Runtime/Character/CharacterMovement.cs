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
            this.targetPosition = position;
            this.moving = true;
        }

        public void Stop()
        {
            this.moving = false;
        }

        private void Update()
        {
            Vector2 direction = (this.targetPosition - (Vector2)this.transform.position).normalized;

            if (this.moving) this.rigidbody.velocity = direction * this.moveSpeed;
        }
    }
}
