using UnityEngine;
using SideScroller.Helpers;
using SideScroller.Model.Unit;
using SideScroller.Model.Item;
using SideScroller.Helpers.Types;
using SideScroller.Helpers.AssetsPath;

namespace SideScroller.Controller
{
    sealed class PlayerLoader
    {
        #region Fields

        private WeaponType _weaponType = WeaponType.Sword;
        private Vector3 _startPosition = Vector3.zero;
        private PlayerCharacterTypes _characterType = PlayerCharacterTypes.Swordsman;

        #endregion


        #region Methods

        private BasePlayerCharacter Build()
        {
            var characterResources = CustomResources.Load<BasePlayerCharacter>(PlayerCharactersAssetPath.CharactersPath[_characterType]);
            var player = Object.Instantiate(characterResources, _startPosition, Quaternion.identity);

            var weaponResources = CustomResources.Load<Weapon>(WeaponsAssetPath.WeaponsPath[_weaponType]);
            var weapon = Object.Instantiate(weaponResources, Vector3.zero, Quaternion.identity, player.transform);

            player.UnitBags.Equipment.Equip(weapon);

            return player;
        }

        public PlayerLoader WithWeapon(WeaponType weaponType)
        {
            _weaponType = weaponType;
            return this;
        }

        public PlayerLoader CreateHero(PlayerCharacterTypes characterType)
        {
            _characterType = characterType;
            return this;
        }
        public PlayerLoader WithStartPosition(Vector3 position)
        {
            _startPosition = position;
            return this;
        }

        public static implicit operator BasePlayerCharacter(PlayerLoader playerLoader)
        {
            return playerLoader.Build();
        }

        #endregion

    }
}