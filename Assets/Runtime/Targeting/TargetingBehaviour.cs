using System.Linq;
using MystiCorp.Runtime.Character;
using MystiCorp.Runtime.Machines;
using UnityEngine;

namespace MystiCorp.Runtime.Targeting
{
    [RequireComponent(typeof(AreaOfEffectBehaviour))]
    public class TargetingBehaviour : MonoBehaviour
    {
        [SerializeField]
        private GameObject currentTarget;
        [Header("Dependencies")]
        [SerializeField]
        private CharacterRegistrar registrar;
        [SerializeField]
        private AreaOfEffectBehaviour areaOfEffectBehaviour;
        
        public GameObject CurrentTarget
        {
            get => currentTarget;
            private set => currentTarget = value;
        }

        private void Update()
        {
            // Probably in the future we want to have this happen at a specified interval rather than every frame since
            // it's unlikely we'll need that level of precision.
            CurrentTarget = GetTarget();
        }

        private GameObject GetTarget()
        {
            GameObject nearest = null;
            var nearestDistance = Mathf.Infinity;
            var thisTransform = transform;
            var facingDirection = thisTransform.up;
            var from = thisTransform.position;
            var radius = areaOfEffectBehaviour.Radius;
            var fieldOfView = areaOfEffectBehaviour.FieldOfView;
            var charactersToEvaluate = registrar.Entities
                .Where(character => !character.CompareTag("Hero"));

            foreach (var character in charactersToEvaluate)
            {
                var to = character.transform.position;
                var distance = Vector2.Distance(from, to);
                var directionToCharacter = (to - from).normalized;
                
                // Exclude targets outside our radius
                if (distance > radius)
                {
                    continue;
                }

                // Exclude targets outside our field of view
                var angleToCharacter = Vector2.Angle(facingDirection, directionToCharacter);

                if (angleToCharacter > fieldOfView / 2f)
                {
                    continue;
                }

                if (nearest != null && distance > nearestDistance)
                {
                    continue;
                }
                
                // Set the current character's GameObject as the nearest and record it's distance as the nearest
                nearest = character.gameObject;
                nearestDistance = distance;
            }
            
            return nearest;
        }
    }
}
