using MystiCorp.Runtime.Attraction;
using UnityEngine;

namespace MystiCorp.Runtime.Machines.Magnet
{
    [RequireComponent(typeof(Attractor))]
    public class OnCycledAttractBehaviour : OnCycledBehaviourBase
    {
        private Attractor attractor;

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
            if (attractor == null)
            {
                attractor = GetComponent<Attractor>();
            }
        }

        protected override void OnCycled()
        {
            attractor.AttractAllNearby();
        }
    }
}
