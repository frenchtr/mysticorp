using TravisRFrench.Attributes.Runtime;
using UnityEngine;

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
    }
}
