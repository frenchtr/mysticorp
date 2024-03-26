using MystiCorp.Runtime.Common.ScriptableEvents;
using MystiCorp.Runtime.Collectibles;
using UnityEngine;

namespace MystiCorp.Runtime.Machines.Collector
{
    [RequireComponent(typeof(Collectibles.Collector))]
    [RequireComponent(typeof(CycleBehaviour))]
    public class OnCycledPickupMagicBehaviour : OnCycledBehaviourBase
    {
        [Header("Events")]
        [SerializeField]
        private GameObjectEvent cycledEvent;
        private Collectibles.Collector magicPickerUpper;
        private CycleBehaviour cycleBehaviour;
        private Collectibles.Collector collector;
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
                magicPickerUpper = GetComponent<Collectibles.Collector>();
            }

            if (cycleBehaviour == null)
            {
                cycleBehaviour = GetComponent<CycleBehaviour>();
                collector = GetComponent<Collectibles.Collector>();
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
