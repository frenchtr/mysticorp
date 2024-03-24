using TravisRFrench.Attributes.Runtime;

namespace MystiCorp.Runtime.Machines
{
    public class MagnitudeModifier : ModifierBase<MagnitudeBehaviour>
    {
        protected override void Modify(MagnitudeBehaviour component, AttributeModifier modifier)
        {
            component.MagnitudeMultiplier.AddModifier(modifier);
        }

        protected override void Unmodify(MagnitudeBehaviour component, AttributeModifier modifier)
        {
            component.MagnitudeMultiplier.RemoveModifier(modifier);
        }
    }
}
