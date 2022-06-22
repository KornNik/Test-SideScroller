using UnityEngine.UI;

namespace SideScroller.Helpers.Extensions
{
    static partial class UIButtonExtension
    {
        #region Methods

        public static void ButtonTextRename(Button button, string buttonText)
        {
            var text = button.GetComponentInChildren<Text>();
            text.text = buttonText;
        }

        #endregion
    }
}