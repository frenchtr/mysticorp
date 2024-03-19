using TravisRFrench.Attributes.Runtime;
using UnityEngine;

namespace MystiCorp.Runtime.Common
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
        
        public float Radius => this.radius * this.RadiusMultiplier.ModifiedValue;
        public float FieldOfView => this.fieldOfView * this.FieldOfViewMultiplier.ModifiedValue;
        
        [field: SerializeField]
        public Attribute RadiusMultiplier { get; private set; }
        [field: SerializeField]
        public Attribute FieldOfViewMultiplier { get; private set; }
        
        public void ForceRecalculateAll()
        {
            this.RadiusMultiplier?.ForceRecalculateModifiedValue();
            this.FieldOfViewMultiplier?.ForceRecalculateModifiedValue();
        }

        private void OnValidate()
        {
            this.ForceRecalculateAll();
        }
    }
}
