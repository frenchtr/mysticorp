using System.Linq;
using MystiCorp.Runtime.Machines;
using UnityEngine;

namespace MystiCorp.Runtime.Attraction
{
    [RequireComponent(typeof(AreaOfEffectBehaviour))]
    [RequireComponent(typeof(CycleBehaviour))]
    public class Attractor : MonoBehaviour
    {
        private AreaOfEffectBehaviour areaOfEffectBehaviour;
        private CycleBehaviour cycleBehaviour;

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
                .GetGameObjectsInAreaOfEffect()
                .OrderByDescending(obj => Vector2.Distance(
                    transform.position, 
                    obj.transform.position))
                .Select(obj => obj.GetComponent<Attractable>())
                .Where(attractor => attractor != null);
            var count = Mathf.FloorToInt(cycleBehaviour.Magnitude);
            
            foreach (var attractable in attractables.Take(count))
            {
                attractable.AttractTo(this);
            }
        }

        private void GetDependencies()
        {
            if (areaOfEffectBehaviour == null)
            {
                areaOfEffectBehaviour = GetComponent<AreaOfEffectBehaviour>();
            }

            if (cycleBehaviour == null)
            {
                cycleBehaviour = GetComponent<CycleBehaviour>();
            }
        }
    }
}
