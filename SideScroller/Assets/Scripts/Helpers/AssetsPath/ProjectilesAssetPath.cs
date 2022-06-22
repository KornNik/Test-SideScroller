using System.Collections.Generic;
using SideScroller.Helpers.Types;

namespace SideScroller.Helpers.AssetsPath
{
    sealed class ProjectilesAssetPath
    {
        #region Fields

        public static readonly Dictionary<ProjectileTypes, string> ProjectilesPath = new Dictionary<ProjectileTypes, string>
        {
            {
                ProjectileTypes.Arrow, "Prefabs/Items/Projectiles/Prefabs_Items_Projectiles_Arrow"
            }

        };

        #endregion
    }
}