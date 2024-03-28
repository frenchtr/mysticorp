using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace MystiCorp.Runtime.UI
{
    public class DropHandler : MonoBehaviour, IDropHandler
    {
        [Header("Event Callbacks")]
        [SerializeField]
        private UnityEvent<PointerEventData> dropped;

        public event Action<PointerEventData> Dropped; 

        public void OnDrop(PointerEventData eventData)
        {
            Drop(eventData);
        }
        
        public void Drop(PointerEventData eventData)
        {
            dropped?.Invoke(eventData);
            Dropped?.Invoke(eventData);
        }
    }
}
