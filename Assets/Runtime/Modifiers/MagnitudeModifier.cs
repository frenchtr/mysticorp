using MystiCorp.Runtime.Machines;
using TravisRFrench.Attributes.Runtime;
using UnityEngine;

namespace MystiCorp.Runtime.Modifiers
{
    public class MagnitudeModifier : MonoBehaviour
    {
        [SerializeField]
        private AttributeModifier modifier;
        private MagnitudeBehaviour mangnitudeBehaviour;

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
            if (mangnitudeBehaviour == null)
            {
                mangnitudeBehaviour = GetComponentInParent<MagnitudeBehaviour>();
            }

            mangnitudeBehaviour.MagnitudeMultiplier.AddModifier(modifier);
        }

        private void OnDisable()
        {
            mangnitudeBehaviour.MagnitudeMultiplier.RemoveModifier(modifier);
        }

        private void GetDependencies()
        {
            if (mangnitudeBehaviour == null)
            {
                mangnitudeBehaviour = GetComponent<MagnitudeBehaviour>();
            }
        }
    }
}
