using System.Collections.Generic;
using SideScroller.Helpers.Types;

namespace SideScroller.Helpers.AssetsPath
{
    sealed class PlayerCharactersAssetPath
    {
        #region Fields

        public static readonly Dictionary<PlayerCharacterTypes, string> CharactersPath = new Dictionary<PlayerCharacterTypes, string>
        {
            {
                PlayerCharacterTypes.Swordsman, "Prefabs/Units/Player/Prefabs_Units_Player_Swordsman"
            },
            {
                PlayerCharacterTypes.Gunner, "Prefabs/Units/Player/Prefabs_Units_Player_Gunner"
            }

        };

        #endregion
    }
}