using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace MystiCorp.Runtime.UI
{
    public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [Header("Event Callbacks")]
        [SerializeField]
        private UnityEvent<PointerEventData> dragStarted;
        [SerializeField]
        private UnityEvent<PointerEventData> dragStopped;

        public bool IsDragging { get; private set; }
        
        public event Action<PointerEventData> DragStarted;
        public event Action<PointerEventData> Dragged; 
        public event Action<PointerEventData> DragStopped;

        public void StartDragging(PointerEventData eventData = null)
        {
            IsDragging = true;
            DragStarted?.Invoke(eventData);
            dragStarted?.Invoke(eventData);
        }

        public void StopDragging(PointerEventData eventData = null)
        {
            IsDragging = false;
            DragStopped?.Invoke(eventData);
            dragStopped?.Invoke(eventData);
        }
        
        void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
        {
            StartDragging(eventData);
        }

        void IDragHandler.OnDrag(PointerEventData eventData)
        {
            Dragged?.Invoke(eventData);
        }

        void IEndDragHandler.OnEndDrag(PointerEventData eventData)
        {
            StopDragging(eventData);
        }
    }
}
