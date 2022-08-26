using System;
using SideScroller.Model.Item;

namespace SideScroller.Model.UnitInventory
{
    class InventoryEventManager
    {
        public Action InventoryChanged;
        public Action EquipmentChanged;
        public Action<BaseItem> ItemMoved;
    }
}
