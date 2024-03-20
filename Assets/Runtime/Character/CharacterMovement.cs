using UnityEngine;

namespace MystiCorp.Runtime.Character
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField]
        private float moveSpeed;
        [SerializeField]
        private float positionPrecision = 0.1f;
        private new Rigidbody2D rigidbody;
        
        private Vector2 targetPosition;

        public bool Moving { get; private set; }

        public void MoveTo(Vector2 position)
        {
            if (rigidbody.position == position) return;

            targetPosition = position;
            Moving = true;
        }

        public void Stop()
        {
            Moving = false;
        }

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
            Vector2 targetDelta = targetPosition - (Vector2)transform.position;
            Vector2 direction = targetDelta.normalized;

            // if reached target
            if (targetDelta.magnitude < positionPrecision)
            {
                rigidbody.MovePosition(targetPosition);
                Moving = false;
                rigidbody.velocity = Vector2.zero;
            }

            if (Moving) rigidbody.velocity = direction * moveSpeed;
        }

        private void GetDependencies()
        {
            if (rigidbody == null)
            {
                rigidbody = GetComponent<Rigidbody2D>();
            }
        }
    }
}
