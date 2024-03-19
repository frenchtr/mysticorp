using MystiCorp.Runtime.Machines;
using TravisRFrench.Attributes.Runtime;
using UnityEngine;

namespace MystiCorp.Runtime.Modifiers
{
    public class RadiusModifier : MonoBehaviour
    {
        [SerializeField]
        private AttributeModifier modifier;
        [Header("Component Dependencies")]
        [SerializeField]
        private MachineIdentity machineIdentity;
        
        private void OnEnable()
        {
            if (this.machineIdentity == null)
            {
                this.machineIdentity = this.GetComponentInParent<MachineIdentity>();
            }

            this.machineIdentity.RadiusMultiplier.AddModifier(this.modifier);
        }

        private void OnDisable()
        {
            this.machineIdentity.RadiusMultiplier.RemoveModifier(this.modifier);
        }
    }
}
