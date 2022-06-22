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

        private WeaponType _weaponType;
        private PlayerCharacterTypes _characterType;

        #endregion


        #region Methods

        private BasePlayerCharacter Build()
        {
            var characterResources = CustomResources.Load<BasePlayerCharacter>(PlayerCharactersAssetPath.CharactersPath[_characterType]);
            var player = Object.Instantiate(characterResources, Vector3.zero, Quaternion.identity);

            var weaponResources = CustomResources.Load<Weapon>(WeaponsAssetPath.WeaponsPath[_weaponType]);
            var weapon = Object.Instantiate(weaponResources, Vector3.zero, Quaternion.identity, player.transform);

            player.Equipment.Equip(weapon);

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

        public static implicit operator BasePlayerCharacter(PlayerLoader playerLoader)
        {
            return playerLoader.Build();
        }

        #endregion

    }
}