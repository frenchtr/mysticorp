using System.Linq;
using MystiCorp.Runtime.Machines;
using UnityEngine;

namespace MystiCorp.Runtime.Collectibles
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
            var collectibles = areaOfEffectBehaviour
                .GetComponentsInAreaOfEffect<Collectible>();

            foreach (var collectible in collectibles.Take(count))
            {
                collectible.Collect();
            }
        }
    }
}
