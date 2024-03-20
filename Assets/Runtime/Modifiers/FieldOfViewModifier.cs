using MystiCorp.Runtime.Machines;
using TravisRFrench.Attributes.Runtime;
using UnityEngine;

namespace MystiCorp.Runtime.Modifiers
{
    public class FieldOfViewModifier : MonoBehaviour
    {
        [SerializeField]
        private AttributeModifier modifier;
        private AreaOfEffectBehaviour areaOfEffectBehaviour;

        private void Awake()
        {
            GetDependencies();
        }

        private void Reset()
        {
            GetDependencies();
        }

        private void OnEnable()
        {
            if (areaOfEffectBehaviour == null)
            {
                areaOfEffectBehaviour = GetComponentInParent<AreaOfEffectBehaviour>();
            }

            areaOfEffectBehaviour.FieldOfViewMultiplier.AddModifier(modifier);
        }

        private void OnDisable()
        {
            areaOfEffectBehaviour.FieldOfViewMultiplier.RemoveModifier(modifier);
        }
        
        private void GetDependencies()
        {
            if (areaOfEffectBehaviour == null)
            {
                areaOfEffectBehaviour = GetComponent<AreaOfEffectBehaviour>();
            }
        }
    }
}
