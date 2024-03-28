using UnityEngine;
using MystiCorp.Runtime.Common.ScriptableEvents;

namespace MystiCorp.Runtime.Machines
{
    public abstract class OnCycledBehaviourBase : MonoBehaviour
    {
        [SerializeField]
        private GameObjectEvent cycledEvent;

        private void OnEnable()
        {
            cycledEvent.Raised += OnCycledInternal;
        }

        private void OnDisable()
        {
            cycledEvent.Raised -= OnCycledInternal;
        }

        private void OnCycledInternal(GameObject obj)
        {
            if (obj == gameObject)
            {
                OnCycled();
            }
        }

        protected abstract void OnCycled();
    }
}
