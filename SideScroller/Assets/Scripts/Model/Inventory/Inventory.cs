using SideScroller.UI.Parts;
using SideScroller.Model.Item;
using SideScroller.Data.Inventory;

namespace SideScroller.Model.UnitInventory
{
    class Inventory
    {
        #region Fields

        private BaseItem[] _itemsInBag;
        private InventoryParameters _inventoryParameters;

        #endregion


        #region Properties

        public BaseItem[] ItemList => _itemsInBag;

        #endregion


        #region ClassLifeCycle

        public Inventory(InventoryParameters inventoryParameters)
        {
            _inventoryParameters = inventoryParameters;
            _itemsInBag = new BaseItem[_inventoryParameters.InventorySize];
        }

        ~Inventory()
        {

        }

        #endregion


        #region Methods

        public void SendItemsToCheck(CharacterInventoryUI inventoryUI)
        {
            inventoryUI.CheckInventoryUI(_itemsInBag);
        }
        public void AddItemToInventory(BaseItem item)
        {
            for (int i = 0; i < _itemsInBag.Length; i++)
            {
                if (_itemsInBag[i] == null)
                {
                    _itemsInBag[i] = item;
                    item.ItemInBag();
                    return;
                }
            }
        }
        public void RemoveItemFromInventory(BaseItem item)
        {
            for (int i = 0; i < _itemsInBag.Length; i++)
            {
                if (_itemsInBag[i] == item)
                {
                    _itemsInBag[i] = null;
                }
            }
        }

        #endregion

    }
}
