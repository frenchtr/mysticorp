using TravisRFrench.Attributes.Runtime;

namespace MystiCorp.Runtime.Machines
{
    public class RadiusModifier : ModifierBase<AreaOfEffectBehaviour>
    {
        protected override void Modify(AreaOfEffectBehaviour component, AttributeModifier modifier)
        {
            component.RadiusMultiplier.AddModifier(modifier);
        }

        protected override void Unmodify(AreaOfEffectBehaviour component, AttributeModifier modifier)
        {
            component.RadiusMultiplier.RemoveModifier(modifier);
        }
    }
}
