using System.Collections.Generic;
using SideScroller.Helpers.Types;

namespace SideScroller.Helpers.AssetsPath
{
    sealed class DatasAssetPath
    {
        #region Fields

        public static Dictionary<DataTypes, string> DatasPath = new Dictionary<DataTypes, string>
        {
            {DataTypes.LevelData,"ScriptableObject/LevelData/LevelForestParameters" },
            {DataTypes.ListPlayerCharacters,"ScriptableObject/ListObjects/PlayerList" },
            {DataTypes.InventoryData,"ScriptableObject/PlayerStats/Inventory/InventoryParameters" }
        };

        #endregion
    }
}