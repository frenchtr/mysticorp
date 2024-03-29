using MystiCorp.Runtime.Common.ScriptableEvents;
using UnityEngine;

namespace MystiCorp.Runtime.Machines.Collector
{
    public class OnCycledPickupMagicBehaviour : MonoBehaviour
    {
        [Header("Events")]
        [SerializeField]
        private GameObjectEvent cycledEvent;

        [Header("Dependencies")]
        [SerializeField]
        private Collectibles.Collector magicPickerUpper;
        [SerializeField]
        private MagnitudeBehaviour magnitudeBehaviour;

        private void OnEnable()
        {
            cycledEvent.Raised += OnCycled;
        }

        private void OnDisable()
        {
            cycledEvent.Raised -= OnCycled;
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
