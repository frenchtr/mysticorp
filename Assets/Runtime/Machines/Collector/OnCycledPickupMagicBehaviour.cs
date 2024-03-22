using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MystiCorp.Runtime.Magic.Pickup;
using MystiCorp.Runtime.Common.ScriptableEvents;
using MystiCorp.Runtime.Machines;

namespace MystiCorp.Runtime
{
    [RequireComponent(typeof(MagicPickerUpper))]
    [RequireComponent(typeof(CycleBehaviour))]
    public class OnCycledPickupMagicBehaviour : MonoBehaviour
    {
        [Header("Events")]
        [SerializeField]
        private GameObjectEvent cycledEvent;
        private MagicPickerUpper magicPickerUpper;
        private CycleBehaviour cycleBehaviour;

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
                magicPickerUpper = GetComponent<MagicPickerUpper>();
            }

            if (cycleBehaviour == null)
            {
                cycleBehaviour = GetComponent<CycleBehaviour>();
            }
        }

        private void OnCycled(GameObject gameObj)
        {
            if (gameObj != gameObject)
            {
                return;
            }

            magicPickerUpper.Pickup(Mathf.FloorToInt(cycleBehaviour.Magnitude));
        }
    }
}
