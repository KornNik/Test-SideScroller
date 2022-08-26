using UnityEngine;
using SideScroller.UI.Parts;
using SideScroller.Model.Item;
using SideScroller.Helpers.Types;
using SideScroller.Helpers;

namespace SideScroller.Model.UnitInventory
{
    class Equipment
    {
        #region Fields

        private Weapon _weapon;
        private ArmorPlaces _armor;
        private Transform _inventoryTransform;

        #endregion


        #region Properties

        public Weapon Weapon => _weapon;
        public ArmorPlaces Armor => _armor;

        #endregion


        #region ClassLifeCycle

        public Equipment(Transform inventoryTransform)
        {
            _inventoryTransform = inventoryTransform;

        }

        ~Equipment()
        {

        }

        #endregion


        #region Methods

        public void SendEquipmentsToCheck(CharacterEquipmentUI equipmentUI)
        {
            equipmentUI.CheckEquipmentUI(_weapon, _armor);
        }
        public void Equip(BaseItem item)
        {
            if (item is Weapon)
            {
                EquipWeapon(item as Weapon);
            }
            else if (item is CommonArmor)
            {
                EquipArmor(item as CommonArmor);
            }

            RenderVisibility.SpriteRenderVisibilityChange(item.transform,item.ItemSpriteRenderer,false);
            ColliderEnabler.ColliderEnabledChanger(item.transform, item.ItemCollider, false);
        }
        public void Unequip(BaseItem item)
        {
            if (item is Weapon)
            {
                _weapon = null;
            }
            else if (item is CommonArmor)
            {

            }
        }

        private void EquipWeapon(Weapon weapon)
        {
            Unequip(_weapon);
            _weapon = weapon;
            _weapon.transform.parent = _inventoryTransform;
            _weapon.transform.localPosition = Vector3.zero;
            _weapon.transform.localRotation = Quaternion.identity;
        }
        private void EquipArmor(CommonArmor armor)
        {
            switch (armor.ArmorType)
            {
                case ArmorTypes.Hands:
                    Unequip(_armor.Hands);
                    _armor.Hands = armor;
                    break;
                case ArmorTypes.Legs:
                    Unequip(_armor.Legs);
                    _armor.Legs = armor;
                    break;
                case ArmorTypes.Body:
                    Unequip(_armor.Body);
                    _armor.Body = armor;
                    break;
                case ArmorTypes.Head:
                    Unequip(_armor.Head);
                    _armor.Head = armor;
                    break;
                default:

                    break;
            }
        }

        #endregion
    }
}
