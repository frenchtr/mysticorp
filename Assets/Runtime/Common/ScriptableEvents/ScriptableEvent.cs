using System;
using UnityEngine;
using UnityEngine.Events;

namespace MystiCorp.Runtime.Common.ScriptableEvents
{
    [CreateAssetMenu(menuName = "Scriptables/Events/Scriptable Event")]
    public class ScriptableEvent : ScriptableObject
    {
        [SerializeField]
        private UnityEvent raised;

        public event Action Raised;

        public void Raise()
        {
            raised?.Invoke();
            Raised?.Invoke();
        }
    }

    public abstract class ScriptableEvent<TData> : ScriptableObject
    {
        [SerializeField]
        private UnityEvent<TData> raised;

        public event Action<TData> Raised;

        public void Raise(TData data)
        {
            raised?.Invoke(data);
            Raised?.Invoke(data);
        }
    }
}
