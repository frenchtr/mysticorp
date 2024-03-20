using MystiCorp.Runtime.Machines;
using TravisRFrench.Attributes.Runtime;
using UnityEngine;

namespace MystiCorp.Runtime.Modifiers
{
    public class CycleTimeModifier : MonoBehaviour
    {
        [SerializeField]
        private AttributeModifier modifier;
        private CycleBehaviour cycleBehaviour;

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
            if (cycleBehaviour == null)
            {
                cycleBehaviour = GetComponentInParent<CycleBehaviour>();
            }

            cycleBehaviour.CycleTimeMultiplier.AddModifier(modifier);
        }

        private void OnDisable()
        {
            cycleBehaviour.CycleTimeMultiplier.RemoveModifier(modifier);
        }

        private void GetDependencies()
        {
            if (cycleBehaviour == null)
            {
                cycleBehaviour = GetComponent<CycleBehaviour>();
            }
        }
    }
}
