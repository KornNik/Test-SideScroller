using SideScroller.UI;
using SideScroller.Helpers;
using SideScroller.UI.Parts;
using SideScroller.Model.Item;
using SideScroller.Model.Unit;
using System.Collections.Generic;

namespace SideScroller.Model.Inventory
{
    class BaseInventory
    {
        #region Fields

        private BaseUnit _unit;

        private BaseItem[] _itemsInBag;

        #endregion


        #region Properties

        public BaseItem[] ItemList => _itemsInBag;

        #endregion


        #region ClassLifeCycle

        public BaseInventory(BaseUnit unit)
        {
            _unit = unit;
            _itemsInBag = new BaseItem[_unit.InventoryParameters.InventorySize];

            CharacterMenu.ItemShiftedInUIInventory += AddItemToInventory;
            CharacterMenu.ItemShiftedInUIEquipment += SelectingItem;

            CharacterInventoryUI.InventoryUIEnabled += CheckInventory;
        }

        ~BaseInventory()
        {
            CharacterMenu.ItemShiftedInUIInventory -= AddItemToInventory;
            CharacterMenu.ItemShiftedInUIEquipment -= SelectingItem;

            CharacterInventoryUI.InventoryUIEnabled -= CheckInventory;
        }

        #endregion


        #region Methods

        private void CheckInventory(ItemCell[] itemCells)
        {
            for (int i = 0; i < _itemsInBag.Length; i++)
            {
                if (_itemsInBag[i] != null)
                {
                    itemCells[i].FillCellInfo(_itemsInBag[i]);
                }
            }
        }

        public void AddItemToInventory(BaseItem item)
        {
            for (int i = 0; i < _itemsInBag.Length; i++)
            {
                if (i == _itemsInBag.Length - 1 && _itemsInBag[i] != null)
                {
                    item.Drop();
                }
                if (_itemsInBag[i] == null)
                {
                    _itemsInBag[i] = item;
                    RenderVisibility.SpriteRenderVisibilityChange(item.transform, item.ItemSpriteRenderer, false);
                    ColliderEnabler.ColliderEnabledChanger(item.transform, item.ItemCollider, false);
                    return;
                }
            }
        }
        public void DeleteItemFromInventory(BaseItem item)
        {
            for (int i = 0; i < _itemsInBag.Length; i++)
            {
                if (_itemsInBag[i] == item)
                {
                    _itemsInBag[i] = null;
                }
            }
        }

        private void SelectingItem(BaseItem item)
        {
            _unit.Equipment.Equip(item);
            DeleteItemFromInventory(item);
        }

        #endregion

    }
}
