using UnityEngine;
using UnityEngine.Serialization;
using Attribute = TravisRFrench.Attributes.Runtime.Attribute;

namespace MystiCorp.Runtime.Machines
{
    public class MachineIdentity : MonoBehaviour
    {
        [Tooltip("How potent should the effects of this machine be?")]
        [SerializeField]
        private float baseMagnitude = 1f;
        [Tooltip("How many times does this machine activate per second?")]
        [SerializeField]
        private float baseCycleTime = 1f;
        
        public float Magnitude => this.baseMagnitude * this.MagnitudeMultiplier.ModifiedValue;
        public float CycleTime => this.baseCycleTime * this.CycleTimeMultiplier.ModifiedValue;

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
