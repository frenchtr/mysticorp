using System.Linq;
using MystiCorp.Runtime.Machines;
using UnityEngine;

namespace MystiCorp.Runtime.Attraction
{
    [RequireComponent(typeof(AreaOfEffectBehaviour))]
    [RequireComponent(typeof(MagnitudeBehaviour))]
    public class Attractor : MonoBehaviour
    {
        private AreaOfEffectBehaviour areaOfEffectBehaviour;
        private MagnitudeBehaviour magnitudeBehaviour;

        private void Awake()
        {
            GetDependencies();
        }

        private void Reset()
        {
            GetDependencies();
        }

        public void AttractAllNearby()
        {
            var attractables = areaOfEffectBehaviour
                .GetComponentsInAreaOfEffect<Attractable>()
                .OrderByDescending(obj => Vector2.Distance(
                    transform.position, 
                    obj.transform.position));
            
            foreach (var attractable in attractables)
            {
                attractable.AttractTo(transform.position, magnitudeBehaviour.Magnitude);
            }
        }

        private void GetDependencies()
        {
            if (areaOfEffectBehaviour == null)
            {
                areaOfEffectBehaviour = GetComponent<AreaOfEffectBehaviour>();
            }

            if (magnitudeBehaviour == null)
            {
                magnitudeBehaviour = GetComponent<MagnitudeBehaviour>();
            }
        }
    }
}
