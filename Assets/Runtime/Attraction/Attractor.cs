using System.Linq;
using MystiCorp.Runtime.Machines;
using UnityEngine;

namespace MystiCorp.Runtime.Attraction
{
    public class Attractor : MonoBehaviour
    {
        [SerializeField]
        private AreaOfEffectBehaviour areaOfEffectBehaviour;
        [SerializeField]
        private MagnitudeBehaviour magnitudeBehaviour;

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
    }
}
