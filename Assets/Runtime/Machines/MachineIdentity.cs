using UnityEngine;
using Attribute = TravisRFrench.Attributes.Runtime.Attribute;

namespace MystiCorp.Runtime.Machines
{
    public class MachineIdentity : MonoBehaviour
    {
        [Tooltip("How potent should the effects of this machine be?")]
        [SerializeField]
        private float magnitude = 1f;
        [Tooltip("How many times does this machine activate per second?")]
        [SerializeField]
        private float cycleTime = 1f;
        [Tooltip("What is the maximum distance that this machine can affect?")]
        [SerializeField]
        private float radius = 1f;
        [Tooltip("What angle does this machine affect, centered on it's transform.up?")]
        [Range(0f, 360f)]
        [SerializeField]
        private float fieldOfView = 360f;
        
        public float Magnitude => this.magnitude * this.MagnitudeMultiplier.ModifiedValue;
        public float CycleTime => this.cycleTime * this.CycleTimeMultiplier.ModifiedValue;
        public float Radius => this.radius * this.RadiusMultiplier.ModifiedValue;
        public float FieldOfView => this.fieldOfView * this.FieldOfViewMultiplier.ModifiedValue;

        [field: SerializeField]
        public Attribute MagnitudeMultiplier { get; private set; }
        [field: SerializeField]
        public Attribute CycleTimeMultiplier { get; private set; }
        [field: SerializeField]
        public Attribute RadiusMultiplier { get; private set; }
        [field: SerializeField]
        public Attribute FieldOfViewMultiplier { get; private set; }

        public void ForceRecalculateAll()
        {
            this.MagnitudeMultiplier.ForceRecalculateModifiedValue();
            this.CycleTimeMultiplier.ForceRecalculateModifiedValue();
            this.RadiusMultiplier.ForceRecalculateModifiedValue();
            this.FieldOfViewMultiplier.ForceRecalculateModifiedValue();
        }

        private void OnValidate()
        {
            this.ForceRecalculateAll();
        }
    }
}
