using System;
using UnityEngine;
using UnityEngine.UI;
using SideScroller.Model.Item;

namespace SideScroller.UI.Parts
{
    class CharacterInventoryUI : MonoBehaviour
    {
        #region Fields

        public static Action<ItemCell[]> InventoryUIEnabled;

        [SerializeField] private ScrollRect _itemsPlace;

        [SerializeField] private ItemCell[] _itemsCellList;

        private int _emptyListCount;

        #endregion


        #region Properties

        public ScrollRect ItemPlace => _itemsPlace;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _itemsPlace = GetComponentInChildren<ScrollRect>();
        }

        private void OnEnable()
        {
            CharacterMenu.ItemShiftedInUIInventory += FillItemCellInUI;
            CharacterMenu.ItemShiftedInUIEquipment += RemoveItemCellFromUI;
            InventoryUIEnabled?.Invoke(_itemsCellList);
        }
        private void OnDisable()
        {
            CharacterMenu.ItemShiftedInUIInventory -= FillItemCellInUI;
            CharacterMenu.ItemShiftedInUIEquipment -= RemoveItemCellFromUI;
        }

        #endregion


        #region Methods

        public void FillItemsArray(ItemCell[] itemCells)
        {
            _itemsCellList = itemCells;
            _emptyListCount = _itemsCellList.Length;
        }

        private void FillItemCellInUI(BaseItem item)
        {
            if (_emptyListCount != 0)
            {
                for (int i = 0; i < _itemsCellList.Length; i++)
                {
                    if (_itemsCellList[i].IsEmpty)
                    {
                        _itemsCellList[i].FillCellInfo(item);
                        _emptyListCount--;
                        return;
                    }
                }
            }
        }
        private void RemoveItemCellFromUI(BaseItem item)
        {
            if (_emptyListCount != _itemsCellList.Length)
            {
                for (int i = 0; i < _itemsCellList.Length; i++)
                {
                    if(_itemsCellList[i].Item == item)
                    {
                        _itemsCellList[i].EmptyCell();
                        _emptyListCount++;
                        return;
                    }
                }
            }
        }

        #endregion
    }
}
