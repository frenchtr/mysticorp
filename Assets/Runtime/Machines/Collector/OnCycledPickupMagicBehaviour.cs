using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MystiCorp.Runtime.Magic.Pickup;
using MystiCorp.Runtime.Common.ScriptableEvents;
using MystiCorp.Runtime.Machines;

namespace MystiCorp.Runtime
{
    [RequireComponent(typeof(Collector))]
    [RequireComponent(typeof(MagnitudeBehaviour))]
    public class OnCycledPickupMagicBehaviour : OnCycledBehaviourBase
    {
        private Collector collector;
        private MagnitudeBehaviour magnitudeBehaviour;

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
            if (collector == null)
            {
                collector = GetComponent<Collector>();
            }

            if (magnitudeBehaviour == null)
            {
                magnitudeBehaviour = GetComponent<MagnitudeBehaviour>();
            }
        }

        protected override void OnCycled()
        {
            collector.Collect(Mathf.FloorToInt(magnitudeBehaviour.Magnitude));
        }
    }
}
