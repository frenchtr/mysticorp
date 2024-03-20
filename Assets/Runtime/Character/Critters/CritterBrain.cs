using UnityEngine;
using Random = UnityEngine.Random;

namespace MystiCorp.Runtime.Character.Critters
{
    public class CritterBrain : MonoBehaviour
    {
        [SerializeField]
        private float minWanderDistance, maxWanderDistance;
        [SerializeField]
        private float minWanderInterval, maxWanderInterval;
        private CharacterMovement movement;

        private Vector2 startPosition;
        private float wanderTimer;

        private void Awake()
        {
            GetDependencies();
        }

        private void Reset()
        {
            GetDependencies();
        }

        private void Start()
        {
            startPosition = transform.position;
        }

        private void Update()
        {
            if (!movement.Moving)
            {
                wanderTimer -= Time.deltaTime;
            }

            if (wanderTimer <= 0)
            {
                wanderTimer = Random.Range(minWanderInterval, maxWanderInterval);

                float wanderDistance = Random.Range(minWanderDistance, maxWanderDistance);
                Vector2 wanderDirection = Random.insideUnitCircle.normalized;
                Vector2 targetPosition = startPosition + wanderDirection * wanderDistance;

                movement.MoveTo(targetPosition);
            }
        }

        private void GetDependencies()
        {
            if (movement == null)
            {
                movement = GetComponent<CharacterMovement>();
            }
        }
    }
}
