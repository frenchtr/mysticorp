using TravisRFrench.Attributes.Runtime;
using UnityEngine;

namespace MystiCorp.Runtime.Machines
{
    public class AreaOfEffectBehaviour : MonoBehaviour
    {
        [Tooltip("What is the maximum distance that this entity can affect?")]
        [SerializeField]
        private float radius = 1f;
        [Tooltip("What angle does this entity affect, centered on it's transform.up?")]
        [Range(0f, 360f)]
        [SerializeField]
        private float fieldOfView = 360f;
        
        public float Radius => radius * RadiusMultiplier.ModifiedValue;
        public float FieldOfView => fieldOfView * FieldOfViewMultiplier.ModifiedValue;
        
        [field: SerializeField]
        public Attribute RadiusMultiplier { get; private set; }
        [field: SerializeField]
        public Attribute FieldOfViewMultiplier { get; private set; }
        
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
