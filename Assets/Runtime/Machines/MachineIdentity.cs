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
        
        public float Magnitude => this.magnitude * this.MagnitudeMultiplier.ModifiedValue;
        public float CycleTime => this.cycleTime * this.CycleTimeMultiplier.ModifiedValue;

        [field: SerializeField]
        public Attribute MagnitudeMultiplier { get; private set; }
        [field: SerializeField]
        public Attribute CycleTimeMultiplier { get; private set; }

        public void ForceRecalculateAll()
        {
            this.MagnitudeMultiplier?.ForceRecalculateModifiedValue();
            this.CycleTimeMultiplier?.ForceRecalculateModifiedValue();
        }

        private void OnValidate()
        {
            this.ForceRecalculateAll();
        }
    }
}
