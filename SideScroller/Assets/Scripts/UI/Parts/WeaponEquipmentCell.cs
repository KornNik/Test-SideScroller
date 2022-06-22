using System;
using UnityEngine;
using UnityEngine.UI;
using SideScroller.Model.Item;
using UnityEngine.EventSystems;
using SideScroller.Helpers.Types;

namespace SideScroller.UI.Parts
{
    class WeaponEquipmentCell : ItemCell
    {
        #region Fields



        #endregion


        #region UnityMethods



        #endregion


        #region Methods

        #endregion


        #region IPointerClickHandler

        public override void OnPointerClick(PointerEventData pointerEventData)
        {
            if (_item is BaseItem)
            {
                CharacterMenu.ItemShiftedInUIInventory?.Invoke(_item);
            }
        }

        #endregion
    }
}
