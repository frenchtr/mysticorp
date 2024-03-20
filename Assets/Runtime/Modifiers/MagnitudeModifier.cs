using MystiCorp.Runtime.Machines;
using TravisRFrench.Attributes.Runtime;
using UnityEngine;

namespace MystiCorp.Runtime.Modifiers
{
    public class MagnitudeModifier : MonoBehaviour
    {
        [SerializeField]
        private AttributeModifier modifier;
        private CycleBehaviour cycleBehaviour;
        
        private void OnEnable()
        {
            if (cycleBehaviour == null)
            {
                cycleBehaviour = GetComponentInParent<CycleBehaviour>();
            }

            cycleBehaviour.MagnitudeMultiplier.AddModifier(modifier);
        }

        private void OnDisable()
        {
            cycleBehaviour.MagnitudeMultiplier.RemoveModifier(modifier);
        }
    }
}