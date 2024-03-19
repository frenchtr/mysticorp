using MystiCorp.Runtime.Machines;
using TravisRFrench.Attributes.Runtime;
using UnityEngine;

namespace MystiCorp.Runtime.Modifiers
{
    public class RadiusModifier : MonoBehaviour
    {
        [SerializeField]
        private AttributeModifier modifier;
        private AreaOfEffectBehaviour areaOfEffectBehaviour;
        
        private void OnEnable()
        {
            if (this.areaOfEffectBehaviour == null)
            {
                this.areaOfEffectBehaviour = this.GetComponentInParent<AreaOfEffectBehaviour>();
            }

            this.areaOfEffectBehaviour.RadiusMultiplier.AddModifier(this.modifier);
        }

        private void OnDisable()
        {
            this.areaOfEffectBehaviour.RadiusMultiplier.RemoveModifier(this.modifier);
        }
    }
}
