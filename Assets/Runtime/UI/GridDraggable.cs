using MystiCorp.Runtime.Common.ScriptableVariables;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MystiCorp.Runtime.UI
{
    public class GridDraggable : MonoBehaviour
    {
        private Vector3 pointerPosition;

        [SerializeField]
        private CameraVariable mainCameraVariable;
        [SerializeField]
        private DragHandler dragHandler;
        [SerializeField]
        private GridData gridData;
        [SerializeField]
        private GameObject gridRenderer;
        private Vector2 pointerOffset;

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
                var mainCamera = mainCameraVariable.Value;
                var pointerWorldPosition = mainCamera.ScreenToWorldPoint(pointerPosition);
                var gridSnappedPosition = gridData.SnapWorldToGridPoint(pointerWorldPosition);

                transform.position = new Vector3()
                {
                    x = gridSnappedPosition.x,
                    y = gridSnappedPosition.y,
                    z = transform.position.z,
                };
            }

            gridRenderer.SetActive(dragHandler.IsDragging);
        }

        private void OnDragged(PointerEventData eventData)
        {
            pointerPosition = eventData.position;
        }
    }
}
