using System;
using MystiCorp.Runtime.Machine_Placement;

namespace MystiCorp.Runtime.Shop
{
    [Serializable]
    public class ShopItem
    {
        public MachineData MachineData { get; set; }
        public float Cost { get; set; }
    }
}
