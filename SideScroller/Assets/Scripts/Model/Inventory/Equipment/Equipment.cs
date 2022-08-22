using UnityEngine;
using SideScroller.UI;
using SideScroller.UI.Parts;
using SideScroller.Model.Item;
using SideScroller.Model.Unit;
using SideScroller.Helpers.Types;
using SideScroller.Helpers;

namespace SideScroller.Model.Inventory
{
    class Equipment
    {
        #region Fields

        private Weapon _weapon;
        private ArmorPlaces _armor;
        private BaseUnit _unit;

        #endregion


        #region Properties

        public Weapon Weapon => _weapon;
        public ArmorPlaces Armor => _armor;

        #endregion


        #region ClassLifeCycle

        public Equipment(BaseUnit unit)
        {
            _unit = unit;
            CharacterMenu.ItemShiftedInUIEquipment += Equip;
            CharacterMenu.ItemShiftedInUIInventory += Unequip;

            CharacterEquipmentUI.EquipmentEnabledUI += CheckEquipment;
        }

        ~Equipment()
        {
            CharacterMenu.ItemShiftedInUIEquipment -= Equip;
            CharacterMenu.ItemShiftedInUIInventory -= Unequip;

            CharacterEquipmentUI.EquipmentEnabledUI -= CheckEquipment;
        }

        #endregion


        #region Methods

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

        private void EquipWeapon(Weapon weapon)
        {
            Unequip(_weapon);
            _weapon = weapon;
            _weapon.transform.parent = _unit.InventoryTransform;
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

        private void Unequip(BaseItem item)
        {
            if(item is Weapon)
            {
                _weapon = null;
            }
            else if (item is CommonArmor)
            {

            }
        }
        private void CheckEquipment(WeaponEquipmentCell weaponEquipmentCell, ArmorEquipmentCell[] armorEquipmentCells)
        {
            if(_weapon != null)
            {
                weaponEquipmentCell.FillCellInfo(_weapon);
            }
            if (_armor.Body != null)
            {
                for (int i = 0; i < armorEquipmentCells.Length; i++)
                {
                    if (armorEquipmentCells[i].ArmorType == _armor.Body.ArmorType)
                    {
                        armorEquipmentCells[i].FillCellInfo(_armor.Body);
                    }
                }
            }
            if (_armor.Hands != null)
            {
                for (int i = 0; i < armorEquipmentCells.Length; i++)
                {
                    if (armorEquipmentCells[i].ArmorType == _armor.Hands.ArmorType)
                    {
                        armorEquipmentCells[i].FillCellInfo(_armor.Hands);
                    }
                }
            }
            if (_armor.Head != null)
            {
                for (int i = 0; i < armorEquipmentCells.Length; i++)
                {
                    if (armorEquipmentCells[i].ArmorType == _armor.Head.ArmorType)
                    {
                        armorEquipmentCells[i].FillCellInfo(_armor.Head);
                    }
                }
            }
            if (_armor.Legs != null)
            {
                for (int i = 0; i < armorEquipmentCells.Length; i++)
                {
                    if (armorEquipmentCells[i].ArmorType == _armor.Legs.ArmorType)
                    {
                        armorEquipmentCells[i].FillCellInfo(_armor.Legs);
                    }
                }
            }
        }

        #endregion
    }
}
