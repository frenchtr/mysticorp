using UnityEngine;
using Attribute = TravisRFrench.Attributes.Runtime.Attribute;

namespace MystiCorp.Runtime.Machines
{
    public class MachineIdentity : MonoBehaviour
    {
        [field: SerializeField]
        public Attribute Magnitude { get; private set; }
        [field: SerializeField]
        public Attribute TimeScale { get; private set; }
        [field: SerializeField]
        public Attribute Radius { get; private set; }
        [field: SerializeField]
        public Attribute FieldOfView { get; private set; }

        public void ForceRecalculateAll()
        {
            this.Magnitude.ForceRecalculateModifiedValue();
            this.TimeScale.ForceRecalculateModifiedValue();
            this.Radius.ForceRecalculateModifiedValue();
            this.FieldOfView.ForceRecalculateModifiedValue();
        }

        private void OnValidate()
        {
            this.ForceRecalculateAll();
        }
    }
}
