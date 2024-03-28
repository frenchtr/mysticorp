using MystiCorp.Runtime.Common.ScriptableEvents;
using MystiCorp.Runtime.Common.ScriptableVariables;
using MystiCorp.Runtime.Shop;
using MystiCorp.Runtime.UI.ShopMenu;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MystiCorp.Runtime.UI.PlacementHUD
{
    public class PlacementHUD : MonoBehaviour
    {
        [SerializeField]
        private CameraVariable mainCameraVariable;
        [SerializeField]
        private DropHandler dropHandler;
        [SerializeField]
        private GameObjectEvent placedEvent;
        [SerializeField]
        private ShopService shopService;
        
        private void OnEnable()
        {
            dropHandler.Dropped += OnDropped;
        }

        private void OnDisable()
        {
            dropHandler.Dropped -= OnDropped;
        }
        
        private void OnDropped(PointerEventData eventData)
        {
            var element = eventData.pointerDrag.GetComponentInParent<ShopMenuElement>();

            var mainCamera = mainCameraVariable.Value;
            var pointerWorldPosition = mainCamera.ScreenToWorldPoint(eventData.position);
            
            var instance = shopService.Purchase(element.ShopItem);

            if (instance == null)
            {
                return;
            }
            
            instance.transform.position = new Vector3()
            {
                x = pointerWorldPosition.x,
                y = pointerWorldPosition.y,
                z = 0f,
            };

            placedEvent.Raise(eventData.pointerDrag);
        }
    }
}
