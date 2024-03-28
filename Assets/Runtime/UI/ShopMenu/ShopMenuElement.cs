using MystiCorp.Runtime.Common.ScriptableEvents;
using MystiCorp.Runtime.Shop;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MystiCorp.Runtime.UI.ShopMenu
{
    public class ShopMenuElement : MonoBehaviour
    {
        [SerializeField]
        private ShopItem shopItem;
        [SerializeField]
        private float previewScale = 100f;
        [SerializeField]
        private GameObject draggable;
        [SerializeField]
        private GameObjectEvent shopElementDragStartedEvent;
        [SerializeField]
        private GameObjectEvent shopElementDragStoppedEvent;
        [SerializeField]
        private Image iconImageComponent;
        [SerializeField]
        private TextMeshProUGUI nameTextComponent;
        [SerializeField]
        private TextMeshProUGUI costTextComponent;
        private GameObject previewInstance;
        
        public ShopItem ShopItem
        {
            get => shopItem;
            set => shopItem = value;
        }

        private void Awake()
        {
            previewInstance = Instantiate(ShopItem.PreviewPrefab, draggable.transform);
            previewInstance.transform.localScale = Vector2.one * previewScale;
            previewInstance.SetActive(false);
            iconImageComponent.sprite = ShopItem.Icon;
            nameTextComponent.text = ShopItem.DisplayName;
            costTextComponent.text = $"{ShopItem.Cost} Magic";
        }

        private void OnEnable()
        {
            shopElementDragStartedEvent.Raised += OnShopElementDragStarted;
            shopElementDragStoppedEvent.Raised += OnShopElementDragStopped;
        }

        private void OnDisable()
        {
            shopElementDragStartedEvent.Raised -= OnShopElementDragStarted;
            shopElementDragStoppedEvent.Raised -= OnShopElementDragStopped;
        }
        
        private void OnShopElementDragStarted(GameObject gameObj)
        {
            if (gameObj != gameObject)
            {
                return;
            }

            previewInstance.SetActive(true);
        }

        private void OnShopElementDragStopped(GameObject gameObj)
        {
            if (gameObj != gameObject)
            {
                return;
            }
            
            previewInstance.SetActive(false);
            draggable.transform.localPosition = Vector2.zero;
        }
    }
}
