using UnityEngine;
using UnityEngine.Events;

namespace MystiCorp.Runtime.Common.ScriptableEvents
{
    public class ScriptableEventListener : MonoBehaviour
    {
        [SerializeField]
        private ScriptableEvent @event;
        [SerializeField]
        private UnityEvent response;

        protected virtual void Awake()
        {
            @event.Raised += OnEventRaised;
        }
        
        protected virtual void OnDestroy()
        {
            @event.Raised -= OnEventRaised;
        }

        private void OnEventRaised()
        {
            response?.Invoke();
        }
    }

    public abstract class ScriptableEventListener<TData> : MonoBehaviour
    {
        [SerializeField]
        private ScriptableEvent<TData> @event;
        [SerializeField]
        private UnityEvent<TData> response;

        protected virtual void Awake()
        {
            @event.Raised += OnEventRaised;
        }
        
        protected virtual void OnDestroy()
        {
            @event.Raised -= OnEventRaised;
        }

        private void OnEventRaised(TData data)
        {
            response?.Invoke(data);
        }
    }
}
