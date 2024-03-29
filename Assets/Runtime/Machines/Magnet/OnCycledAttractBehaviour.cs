using MystiCorp.Runtime.Attraction;
using UnityEngine;

namespace MystiCorp.Runtime.Machines.Magnet
{
    public class OnCycledAttractBehaviour : OnCycledBehaviourBase
    {
        [SerializeField]
        private Attractor attractor;

        protected override void OnCycled()
        {
            attractor.AttractAllNearby();
        }
    }
}
