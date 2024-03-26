using TravisRFrench.Attributes.Runtime;

namespace MystiCorp.Runtime.Machines.FieldOfViewModifier
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
