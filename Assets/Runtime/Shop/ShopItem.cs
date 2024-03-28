using UnityEngine;

namespace MystiCorp.Runtime.Shop
{
    [CreateAssetMenu(menuName = "Scriptables/Shop Item")]
    public class ShopItem : ScriptableObject
    {
        [SerializeField]
        private string displayName;
        [SerializeField]
        private float cost;
        [SerializeField]
        private Sprite icon;
        [SerializeField]
        private GameObject previewPrefab;
        [SerializeField]
        private GameObject placePrefab;

        public string DisplayName
        {
            get => displayName;
            set => displayName = value;
        }
        public float Cost
        {
            get => cost;
            set => cost = value;
        }
        public Sprite Icon
        {
            get => icon;
            set => icon = value;
        }
        public GameObject PreviewPrefab
        {
            get => previewPrefab;
            set => previewPrefab = value;
        }

        public GameObject PlacePrefab
        {
            get => placePrefab;
            set => placePrefab = value;
        }
    }
}
