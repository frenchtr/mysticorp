using System.Collections.Generic;
using MystiCorp.Runtime.Common.ScriptableVariables;
using UnityEngine;
using MystiCorp.Runtime.Machines;
using System.Linq;

namespace MystiCorp.Runtime.Magic.Pickup
{
    [RequireComponent(typeof(AreaOfEffectBehaviour))]
    public class MagicCollector : MonoBehaviour
    {
        [SerializeField]
        private FloatVariable magicAmount;
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

        public void Pickup(int count)
        {
            List<MagicPickup> pickups = new();

            foreach (var gameObject in areaOfEffectBehaviour.GetGameObjectsInAreaOfEffect())
            {
                if (gameObject.TryGetComponent(out MagicPickup pickup))
                {
                    pickups.Add(pickup);
                }

                if (pickups.Count == count) break;
            }

            foreach (var pickup in pickups)
            {
                magicAmount.Value += pickup.Pickup();
            }
        }
    }
}
