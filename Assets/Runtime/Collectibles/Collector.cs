using System.Collections.Generic;
using MystiCorp.Runtime.Common.ScriptableVariables;
using UnityEngine;
using MystiCorp.Runtime.Machines;
using System.Linq;

namespace MystiCorp.Runtime.Magic.Pickup
{
    [RequireComponent(typeof(AreaOfEffectBehaviour))]
    public class Collector : MonoBehaviour
    {
        [SerializeField]
        private AreaOfEffectBehaviour areaOfEffectBehaviour;

        private void Awake()
        {
            GetDependencies();
        }

        private void Reset()
        {
            GetDependencies();
        }

        private void GetDependencies()
        {
            if (areaOfEffectBehaviour == null)
            {
                areaOfEffectBehaviour = GetComponent<AreaOfEffectBehaviour>();
            }
        }

        public void Collect(int count)
        {
            int collected = 0;

            foreach (var gameObject in areaOfEffectBehaviour.GetGameObjectsInAreaOfEffect())
            {
                if (gameObject.TryGetComponent(out Collectible collectible))
                {
                    collectible.Collect();
                    collected++;
                }

                if (collected == count) break;
            }
        }
    }
}
