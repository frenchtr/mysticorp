using System;
using System.Collections.Generic;
using MystiCorp.Runtime.Common.ScriptableVariables;
using MystiCorp.Runtime.GameManager;
using MystiCorp.Runtime.Machine_Placement;
using UnityEngine;
using UnityEngine.Serialization;

namespace MystiCorp.Runtime.Shop
{
    public class ShopService : GameServiceManager.Service
    {
        [SerializeField]
        private List<ShopItem> inventory;
        [SerializeField]
        private FloatVariable magicAmountVariable;
        
        public void Purchase(ShopItem item)
        {
            // Can't afford it? Return.
            if (magicAmountVariable.Value <= item.Cost)
            {
                return;
            }

            magicAmountVariable.Value = Mathf.Max(magicAmountVariable.Value - item.Cost, 0f);
        }

        public void Refund(ShopItem item)
        {
            throw new NotImplementedException();
        }
        
        public void Refund(MachineData machineData)
        {
            throw new NotImplementedException();
        }
    }
}
