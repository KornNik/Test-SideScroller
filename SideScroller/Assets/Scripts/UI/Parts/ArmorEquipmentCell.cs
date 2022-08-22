using UnityEngine;
using SideScroller.Model.Item;
using UnityEngine.EventSystems;
using SideScroller.Helpers.Types;

namespace SideScroller.UI.Parts
{
    class ArmorEquipmentCell : ItemCell
    {
        #region Fields

        [SerializeField] private ArmorTypes _armorType;

        #endregion


        #region Properties

        public ArmorTypes ArmorType => _armorType;

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
