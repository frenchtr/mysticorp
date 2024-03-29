using System.Linq;
using MystiCorp.Runtime.Machines;
using UnityEngine;

namespace MystiCorp.Runtime.Collectibles
{
    public class Collector : MonoBehaviour
    {
        [SerializeField]
        private AreaOfEffectBehaviour areaOfEffectBehaviour;

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
