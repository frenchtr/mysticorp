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
        
        public float Radius => baseRadius * RadiusMultiplier.ModifiedValue;
        public float FieldOfView => 
            Mathf.Clamp(baseFieldOfView * FieldOfViewMultiplier.ModifiedValue, 0f, 360f);
        
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
