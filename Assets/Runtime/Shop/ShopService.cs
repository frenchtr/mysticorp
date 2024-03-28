using MystiCorp.Runtime.Common.ScriptableVariables;
using MystiCorp.Runtime.GameManager;
using UnityEngine;

namespace MystiCorp.Runtime.Shop
{
    [CreateAssetMenu(menuName = "Scriptables/Services/Shop Service")]
    public class ShopService : GameServiceManager.Service
    {
        [SerializeField]
        private FloatVariable magicAmountVariable;
        
        public GameObject Purchase(ShopItem item)
        {
            if (magicAmountVariable.Value - item.Cost < 0)
            {
                return null;
            }

            magicAmountVariable.Value -= item.Cost;

            var instance = Instantiate(item.PlacePrefab);

            return instance;
        }
    }
}
