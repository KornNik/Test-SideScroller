using UnityEngine;
using SideScroller.Helpers;
using SideScroller.Model.Unit;
using SideScroller.Model.Item;
using SideScroller.Helpers.Types;
using SideScroller.Helpers.AssetsPath;

namespace SideScroller.Controller
{
    class NPCLoader
    {
        #region Fields

        private NPCTypes _NPCType = NPCTypes.Bandit;
        private WeaponType _weaponType = WeaponType.Sword;
        private Vector3 _startPosition;

        #endregion


        #region Methods

        private BaseNPC Build()
        {
            var NPCResources = CustomResources.Load<BaseNPC>(NPCsAssetPath.NPCsPath[_NPCType]);
            var NPC = Object.Instantiate(NPCResources, _startPosition, Quaternion.identity);

            var weaponResources = CustomResources.Load<Weapon>(WeaponsAssetPath.WeaponsPath[_weaponType]);
            var weapon = Object.Instantiate(weaponResources, Vector3.zero, Quaternion.identity, NPC.transform);

            NPC.UnitBags.Equipment.Equip(weapon);

            return NPC;
        }

        public NPCLoader WithWeapon(WeaponType weaponType)
        {
            _weaponType = weaponType;
            return this;
        }

        public NPCLoader CreateNPC(NPCTypes characterType)
        {
            _NPCType = characterType;
            return this;
        }
        public NPCLoader WithStartPosition(Vector3 position)
        {
            _startPosition = position;
            return this;
        }

        public static implicit operator BaseNPC(NPCLoader NPCLoader)
        {
            return NPCLoader.Build();
        }

        #endregion
    }
}
