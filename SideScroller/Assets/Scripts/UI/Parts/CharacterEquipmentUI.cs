using System;
using UnityEngine;
using SideScroller.Helpers.Types;
using SideScroller.Model.Item;
using SideScroller.Model.UnitInventory;

namespace SideScroller.UI.Parts
{
    class CharacterEquipmentUI : MonoBehaviour
    {
        #region Fields

        [SerializeField] private WeaponEquipmentCell _weaponEquipmentCell;
        [SerializeField] private ArmorEquipmentCell[] _armorEquipmentCells;

        public static Action<CharacterEquipmentUI> EquipmentUIChecking;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _weaponEquipmentCell = GetComponentInChildren<WeaponEquipmentCell>();
            _armorEquipmentCells = GetComponentsInChildren<ArmorEquipmentCell>();
        }
        private void OnEnable()
        {
            CharacterMenu.EquipmentItemSelected += ClearEquipmentCell;
            CharacterMenu.InventoryItemSelected += FillEquipmentCell;
        }
        private void OnDisable()
        {
            CharacterMenu.EquipmentItemSelected -= ClearEquipmentCell;
            CharacterMenu.InventoryItemSelected -= FillEquipmentCell;
        }

        #endregion


        #region Methods

        public void CheckEquipmentUI(Weapon weapon, ArmorPlaces armors)
        {
            var legsCell = FindArmorCellByType(ArmorTypes.Legs);
            var headCell = FindArmorCellByType(ArmorTypes.Head);
            var handsCell = FindArmorCellByType(ArmorTypes.Hands);
            var bodyCell = FindArmorCellByType(ArmorTypes.Body);

            if (weapon != null)
            {
                FillEquipmentCell(weapon);
            }
            else if (weapon == null && _weaponEquipmentCell != null)
            {
                _weaponEquipmentCell.EmptyCell();
            }

            if (armors.Legs != null)
            {
                FillEquipmentCell(armors.Legs);
            }
            else if (armors.Legs == null && legsCell.Item != null)
            {
                legsCell.FillCellInfo(armors.Legs);
            }

            if (armors.Head != null)
            {
                FillEquipmentCell(armors.Head);
            }
            else if (armors.Head == null && headCell.Item != null)
            {
                headCell.FillCellInfo(armors.Head);
            }

            if (armors.Hands != null)
            {
                FillEquipmentCell(armors.Hands);
            }
            else if (armors.Hands == null && handsCell.Item != null)
            {
                handsCell.FillCellInfo(armors.Hands);
            }

            if (armors.Body != null)
            {
                FillEquipmentCell(armors.Body);
            }
            else if (armors.Body == null && bodyCell.Item != null)
            {
                bodyCell.FillCellInfo(armors.Body);
            }

        }

        private void FillEquipmentCell(BaseItem item)
        {
            if (item is Weapon)
            {
                FillWeaponCell(item as Weapon);
            }
            else if(item is CommonArmor)
            {
                FillArmorCell(item as CommonArmor);
            }
        }
        private void ClearEquipmentCell(BaseItem item)
        {
            if (item is CommonArmor)
            {
                ClearArmorCell(item as CommonArmor);
            }
            else if(item is Weapon)
            {
                ClearWeaponCell();
            }
        }
        private void FillWeaponCell(Weapon weapon)
        {
            _weaponEquipmentCell.FillCellInfo(weapon);
        }
        private void ClearWeaponCell()
        {
            _weaponEquipmentCell.EmptyCell();
        }
        private void FillArmorCell(CommonArmor armor)
        {
            var armorCell = FindArmorCellByType(armor.ArmorType);
            if (armorCell != null)
            {
                armorCell.FillCellInfo(armor);
            }
        }
        private void ClearArmorCell(CommonArmor armor)
        {
            var armorCell = FindArmorCellByType(armor.ArmorType);
            if (armorCell != null)
            {
                armorCell.EmptyCell();
            }
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
