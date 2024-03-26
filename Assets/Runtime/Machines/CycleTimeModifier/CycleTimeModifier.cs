using TravisRFrench.Attributes.Runtime;

namespace MystiCorp.Runtime.Machines.CycleTimeModifier
{
    public class CycleTimeModifier : ModifierBase<CycleBehaviour>
    {
        protected override void Modify(CycleBehaviour component, AttributeModifier modifier)
        {
            component.CycleTimeMultiplier.AddModifier(modifier);
        }

        protected override void Unmodify(CycleBehaviour component, AttributeModifier modifier)
        {
            component.CycleTimeMultiplier.RemoveModifier(modifier);
        }
    }
}
