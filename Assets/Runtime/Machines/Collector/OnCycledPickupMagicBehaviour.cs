using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MystiCorp.Runtime.Magic.Pickup;
using MystiCorp.Runtime.Common.ScriptableEvents;
using MystiCorp.Runtime.Machines;

namespace MystiCorp.Runtime
{
    [RequireComponent(typeof(Collector))]
    [RequireComponent(typeof(CycleBehaviour))]
    [RequireComponent(typeof(MagnitudeBehaviour))]
    public class OnCycledPickupMagicBehaviour : MonoBehaviour
    {
        [Header("Events")]
        [SerializeField]
        private GameObjectEvent cycledEvent;
        private Collector magicPickerUpper;
        private CycleBehaviour cycleBehaviour;
        private MagnitudeBehaviour magnitudeBehaviour;

        private void Awake()
        {
            GetDependencies();
        }

        private void Reset()
        {
            GetDependencies();
        }

        private void OnEnable()
        {
            cycledEvent.Raised += OnCycled;
        }

        private void OnDisable()
        {
            cycledEvent.Raised -= OnCycled;
        }

        private void GetDependencies()
        {
            if (magicPickerUpper == null)
            {
                magicPickerUpper = GetComponent<Collector>();
            }

            if (cycleBehaviour == null)
            {
                cycleBehaviour = GetComponent<CycleBehaviour>();
            }

            if (magnitudeBehaviour == null)
            {
                magnitudeBehaviour = GetComponent<MagnitudeBehaviour>();
            }
        }

        private void OnCycled(GameObject gameObj)
        {
            if (gameObj != gameObject)
            {
                return;
            }

            magicPickerUpper.Collect(Mathf.FloorToInt(magnitudeBehaviour.Magnitude));
        }
    }
}
