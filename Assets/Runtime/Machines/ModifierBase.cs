using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TravisRFrench.Attributes.Runtime;
using System.Linq;

namespace MystiCorp.Runtime.Machines
{
    [RequireComponent(typeof(AreaOfEffectBehaviour))]
    public abstract class ModifierBase<TComponent> : MonoBehaviour
    {
        [SerializeField]
        private AttributeModifier modifier;
        [SerializeField]
        private AreaOfEffectBehaviour areaOfEffectBehaviour;

        private List<TComponent> effectedMachines;

        protected abstract void Modify(TComponent component, AttributeModifier modifier);
        protected abstract void Unmodify(TComponent component, AttributeModifier modifier);

        private void Awake()
        {
            GetDependencies();

            effectedMachines = new();
        }

        private void Reset()
        {
            GetDependencies();
        }

        private void Update()
        {
            // running this in update to make sure it works, probably not performant though
            ModifyEffectedMachines();
        }

        private void OnDisable()
        {
            RemoveAllModifications();
        }

        private void ModifyEffectedMachines()
        {
            var machines = areaOfEffectBehaviour
                .GetComponentsInAreaOfEffect<TComponent>();

            // modify all new machines
            foreach (var machine in machines)
            {
                if (!effectedMachines.Contains(machine))
                {
                    effectedMachines.Add(machine);
                    Modify(machine, modifier);
                }
            }

            // unmodify all machines that are no longer effected
            foreach (var machine in effectedMachines.ToList())
            {
                if (!machines.Contains(machine))
                {
                    effectedMachines.Remove(machine);
                    Unmodify(machine, modifier);
                }
            }
        }

        private void RemoveAllModifications()
        {
            foreach (var machine in effectedMachines)
            {
                Unmodify(machine, modifier);
            }

            effectedMachines.Clear();
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
