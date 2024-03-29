using MystiCorp.Runtime.Common.ScriptableVariables;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MystiCorp.Runtime.UI
{
    [RequireComponent(typeof(DragHandler))]
    public class Draggable : MonoBehaviour
    {
        private Vector3 pointerPosition;

        [SerializeField]
        private CameraVariable mainCameraVariable;
        [SerializeField]
        private DragHandler dragHandler;
        private Vector2 pointerOffset;

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
            dragHandler.Dragged += OnDragged;
        }

        private void OnDisable()
        {
            dragHandler.Dragged -= OnDragged;
        }

        private void Update()
        {
            if (dragHandler.IsDragging)
            {
                var rectTransform = gameObject.GetComponent<RectTransform>();
                var mainCamera = mainCameraVariable.Value;
                var pointerWorldPosition = mainCamera.ScreenToWorldPoint(pointerPosition);
            
                rectTransform.position = new Vector3()
                {
                    x = pointerWorldPosition.x,
                    y = pointerWorldPosition.y,
                    z = rectTransform.position.z,
                };
            }
        }

        private void GetDependencies()
        {
            if (dragHandler == null)
            {
                dragHandler = GetComponent<DragHandler>();
            }
        }
        
        private void OnDragged(PointerEventData eventData)
        {
            pointerPosition = eventData.position;
        }
    }
}
