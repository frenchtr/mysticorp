using TravisRFrench.Attributes.Runtime;
using UnityEngine;

namespace MystiCorp.Runtime.Machines
{
    public class FieldOfViewModifier : ModifierBase<AreaOfEffectBehaviour>
    {
        protected override void Modify(AreaOfEffectBehaviour component, AttributeModifier modifier)
        {
            component.FieldOfViewMultiplier.AddModifier(modifier);
        }

        protected override void Unmodify(AreaOfEffectBehaviour component, AttributeModifier modifier)
        {
            component.FieldOfViewMultiplier.RemoveModifier(modifier);
        }
    }
}
