using MystiCorp.Runtime.Attraction;
using MystiCorp.Runtime.Common.ScriptableEvents;
using UnityEngine;

namespace MystiCorp.Runtime.Machines.MagnetMachine
{
    [RequireComponent(typeof(Attractor))]
    public class OnCycledAttractBehaviour : MonoBehaviour
    {
        [Header("Events")]
        [SerializeField]
        private GameObjectEvent cycledEvent;
        private Attractor attractor;

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
            if (attractor == null)
            {
                attractor = GetComponent<Attractor>();
            }
        }

        private void OnCycled(GameObject gameObj)
        {
            if (gameObj != this.gameObject)
            {
                return;
            }
            
            attractor.AttractAllNearby();
        }
    }
}
