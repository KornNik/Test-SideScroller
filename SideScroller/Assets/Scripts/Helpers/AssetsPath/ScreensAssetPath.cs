using System.Collections.Generic;
using SideScroller.UI.Types;

namespace SideScroller.Helpers.AssetsPath
{
    sealed class ScreenAssetPath
    {
        #region Struct

        public struct ScreenPath
        {
            public string Screen;
            public Dictionary<ScreenElementTypes, string> Elements;
        }

        #endregion

        #region Fields

        public static readonly Dictionary<ScreenTypes, ScreenPath> Screens = new Dictionary<ScreenTypes, ScreenPath>
        {
            {
                ScreenTypes.Canvas,
                new ScreenPath
                {
                    Screen = "Prefabs/UI/Prefabs_UI_Canvas",
                    Elements = new Dictionary<ScreenElementTypes, string>()
                }
            },

            {
                ScreenTypes.MainMenu,
                new ScreenPath
                {
                    Screen = "Prefabs/UI/Screens/Prefabs_UI_Screens_MainMenu",
                    Elements = new Dictionary<ScreenElementTypes, string>()
                }
            },

            {
                ScreenTypes.ChooseCharacterMenu,
                new ScreenPath
                {
                    Screen = "Prefabs/UI/Screens/Prefabs_UI_Screens_ChooseCharacterMenu",
                    Elements = new Dictionary<ScreenElementTypes, string>()
                    {
                        { ScreenElementTypes.SelectCharacterCell,"Prefabs/UI/Parts/Prefabs_UI_Parts_SelectCharacterCell" }
                    }
                }
            },

            {
                ScreenTypes.GameMenu,
                new ScreenPath
                {
                    Screen = "Prefabs/UI/Screens/Prefabs_UI_Screens_GameMenu",
                    Elements = new Dictionary<ScreenElementTypes, string>()
                }
            },
            {
                ScreenTypes.InventoryMenu,
                new ScreenPath
                {
                    Screen = "Prefabs/UI/Screens/Prefabs_UI_Screens_InventoryMenu",
                    Elements = new Dictionary<ScreenElementTypes, string>()
                    {
                        {ScreenElementTypes.ItemCell,"Prefabs/UI/Parts/Prefabs_UI_Parts_ItemCell" }
                    }
                }
            }
        };

        #endregion
    }
}