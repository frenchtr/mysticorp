using System.Collections.Generic;
using System.Linq;
using TravisRFrench.Attributes.Runtime;
using UnityEngine;

namespace MystiCorp.Runtime.Machines
{
    public class AreaOfEffectBehaviour : MonoBehaviour
    {
        [Tooltip("What is the maximum distance that this entity can affect?")]
        [SerializeField]
        private float baseRadius = 1f;
        [Tooltip("What angle does this entity affect, centered on it's transform.up?")]
        [Range(0f, 360f)]
        [SerializeField]
        private float baseFieldOfView = 360f;
        [Header("GameObject Detection")]
        [SerializeField]
        private LayerMask layerMask;
        [SerializeField]
        private float minDepth = 0;
        [SerializeField]
        private float maxDepth = float.MaxValue;

        public float Radius => baseRadius * RadiusMultiplier.ModifiedValue;
        public float FieldOfView => 
            Mathf.Clamp(baseFieldOfView * FieldOfViewMultiplier.ModifiedValue, 0f, 360f);
        
        [field: SerializeField]
        public Attribute RadiusMultiplier { get; private set; } = new() { BaseValue = 1 };
        [field: SerializeField]
        public Attribute FieldOfViewMultiplier { get; private set; } = new() { BaseValue = 1 };

        public IEnumerable<GameObject> GetGameObjectsInAreaOfEffect()
        {
            var results = new List<GameObject>();
            var thisTransform = transform;
            var from = thisTransform.position;
            var facingDirection = thisTransform.up;
            var colliders = Physics2D.OverlapCircleAll(
                from,
                Radius,
                layerMask,
                minDepth,
                maxDepth);

            foreach (var cldr in colliders)
            {
                var to = cldr.transform.position;
                var directionToGameObject = (to - from).normalized;
                
                // Exclude the collider on this GameObject
                if (cldr.gameObject == gameObject)
                {
                    continue;
                }

                // Exclude targets outside our field of view
                var angleToGameObject = Vector2.Angle(facingDirection, directionToGameObject);

                if (angleToGameObject > FieldOfView / 2f)
                {
                    continue;
                }

                results.Add(cldr.gameObject);
            }

            return results;
        }

        public void ForceRecalculateAll()
        {
            RadiusMultiplier?.ForceRecalculateModifiedValue();
            FieldOfViewMultiplier?.ForceRecalculateModifiedValue();
        }

        private void OnValidate()
        {
            ForceRecalculateAll();
        }
    }
}
