using System;
using UnityEngine;
using UnityEngine.UI;
using SideScroller.Model.Item;

namespace SideScroller.UI.Parts
{
    class CharacterInventoryUI : MonoBehaviour
    {
        #region Fields

        [SerializeField] private ScrollRect _itemsPlace;
        [SerializeField] private ItemCell[] _itemsCellArray;

        public static Action<CharacterInventoryUI> InventoryUIChecking;

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
            CharacterMenu.EquipmentItemSelected += FillItemCell;
            CharacterMenu.InventoryItemSelected += ClearItemCell;

        }
        private void OnDisable()
        {
            CharacterMenu.EquipmentItemSelected -= FillItemCell;
            CharacterMenu.InventoryItemSelected -= ClearItemCell;
        }

        #endregion


        #region Methods

        public void FillItemsArray(ItemCell[] itemCells)
        {
            _itemsCellArray = itemCells;
            _emptyListCount = _itemsCellArray.Length;
        }
        public void CheckInventoryUI(BaseItem[] items)
        {
            for (int i = 0; i < _itemsCellArray.Length; i++)
            {
                if (items[i] != null)
                {
                    _itemsCellArray[i].EmptyCell();
                    _itemsCellArray[i].FillCellInfo(items[i]);
                }
                else if (items[i] == null && _itemsCellArray[i].Item != null)
                {
                    _itemsCellArray[i].EmptyCell();
                }
            }
        }

        private void FillItemCell(BaseItem item)
        {
            if (_emptyListCount != 0)
            {
                for (int i = 0; i < _itemsCellArray.Length; i++)
                {
                    if (_itemsCellArray[i].IsEmpty)
                    {
                        _itemsCellArray[i].FillCellInfo(item);
                        _emptyListCount--;
                        return;
                    }
                }
            }
        }
        private void ClearItemCell(BaseItem item)
        {
            if (_emptyListCount != _itemsCellArray.Length)
            {
                for (int i = 0; i < _itemsCellArray.Length; i++)
                {
                    if(_itemsCellArray[i].Item == item)
                    {
                        _itemsCellArray[i].EmptyCell();
                        _emptyListCount++;
                        return;
                    }
                }
            }
        }

        #endregion
    }
}
