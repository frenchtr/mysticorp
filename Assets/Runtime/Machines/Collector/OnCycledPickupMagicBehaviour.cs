using MystiCorp.Runtime.Common.ScriptableEvents;
using UnityEngine;

namespace MystiCorp.Runtime.Machines.Collector
{
<<<<<<< HEAD
    [RequireComponent(typeof(Collectibles.Collector))]
    [RequireComponent(typeof(CycleBehaviour))]
=======
    [RequireComponent(typeof(Collector))]
>>>>>>> a82af700d7b38448a27cf3c5278946653b13519c
    [RequireComponent(typeof(MagnitudeBehaviour))]
    public class OnCycledPickupMagicBehaviour : OnCycledBehaviourBase
    {
<<<<<<< HEAD
        [Header("Events")]
        [SerializeField]
        private GameObjectEvent cycledEvent;
        private Collectibles.Collector magicPickerUpper;
        private CycleBehaviour cycleBehaviour;
=======
        private Collector collector;
>>>>>>> a82af700d7b38448a27cf3c5278946653b13519c
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
<<<<<<< HEAD
                magicPickerUpper = GetComponent<Collectibles.Collector>();
            }

            if (cycleBehaviour == null)
            {
                cycleBehaviour = GetComponent<CycleBehaviour>();
=======
                collector = GetComponent<Collector>();
>>>>>>> a82af700d7b38448a27cf3c5278946653b13519c
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
