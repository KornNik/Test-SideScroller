using System.Collections.Generic;
using SideScroller.Helpers.Types;

namespace SideScroller.Helpers.AssetsPath
{
    sealed class NPCsAssetPath
    {
        #region Fields

        public static readonly Dictionary<NPCTypes, string> NPCsPath = new Dictionary<NPCTypes, string>
        {
            {
                NPCTypes.Bandit, "Prefabs/Units/NPC/Prefabs_Units_NPC_Bandit"
            },
            {
                NPCTypes.Thing, "Prefabs/Units/NPC/Prefabs_Units_NPC_Thing"
            }

        };

        #endregion
    }
}