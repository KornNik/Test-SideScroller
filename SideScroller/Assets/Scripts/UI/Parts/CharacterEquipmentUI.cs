using System;
using UnityEngine;
using SideScroller.Helpers.Types;
using SideScroller.Model.Item;

namespace SideScroller.UI.Parts
{
    class CharacterEquipmentUI : MonoBehaviour
    {
        #region Fields

        public static Action<WeaponEquipmentCell, ArmorEquipmentCell[]> EquipmentEnabledUI;

        [SerializeField] private WeaponEquipmentCell _weaponEquipmentCell;
        [SerializeField] private ArmorEquipmentCell[] _armorEquipmentCells;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _weaponEquipmentCell = GetComponentInChildren<WeaponEquipmentCell>();
            _armorEquipmentCells = GetComponentsInChildren<ArmorEquipmentCell>();
        }
        private void OnEnable()
        {
            CharacterMenu.ItemShiftedInUIEquipment += AddEquipmentInUI;
            CharacterMenu.ItemShiftedInUIInventory += RemoveEquipmentFromUI;
            EquipmentEnabledUI?.Invoke(_weaponEquipmentCell,_armorEquipmentCells);
        }
        private void OnDisable()
        {
            CharacterMenu.ItemShiftedInUIEquipment -= AddEquipmentInUI;
            CharacterMenu.ItemShiftedInUIInventory -= RemoveEquipmentFromUI;
        }

        #endregion


        #region Methods

        private void AddEquipmentInUI(BaseItem item)
        {
            if(item is Weapon)
            {
                AddWeaponCell(item as Weapon);
            }
            else if(item is CommonArmor)
            {
                AddArmorCell(item as CommonArmor);
            }
        }
        private void RemoveEquipmentFromUI(BaseItem item)
        {
            if (item is CommonArmor)
            {
                RemoveArmorCell(item as CommonArmor);
            }
            else
            {
                RemoveWeaponCell();
            }
        }

        private void RemoveWeaponCell()
        {
            _weaponEquipmentCell.EmptyCell();
        }
        private void RemoveArmorCell(CommonArmor armor)
        {
            FindArmorCellByType(armor.ArmorType).EmptyCell();
        }

        private void AddWeaponCell(Weapon weapon)
        {
            _weaponEquipmentCell.FillCellInfo(weapon);
        }
        private void AddArmorCell(CommonArmor armor)
        {
            FindArmorCellByType(armor.ArmorType).FillCellInfo(armor);
        }

        private ArmorEquipmentCell FindArmorCellByType(ArmorTypes armorType)
        {
            for (int i = 0; i < _armorEquipmentCells.Length; i++)
            {
                if (_armorEquipmentCells[i].ArmorType == armorType)
                {
                    return _armorEquipmentCells[i];
                }
            }
            return null;
        }

        #endregion
    }
}
