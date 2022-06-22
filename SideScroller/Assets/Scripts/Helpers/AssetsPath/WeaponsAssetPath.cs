using System.Collections.Generic;
using SideScroller.Helpers.Types;

namespace SideScroller.Helpers.AssetsPath
{
    sealed class WeaponsAssetPath
    {
        #region Fields

        public static readonly Dictionary<WeaponType, string> WeaponsPath = new Dictionary<WeaponType, string>
        {
            {
                WeaponType.Sword, "Prefabs/Items/Weapons/Prefabs_Items_Weapons_CommonSword"
            }

        };

        #endregion
    }
}
