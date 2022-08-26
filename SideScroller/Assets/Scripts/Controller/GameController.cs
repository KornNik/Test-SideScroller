using UnityEngine;
using SideScroller.UI;
using SideScroller.UI.Types;

namespace SideScroller.Controller
{
    class GameController : MonoBehaviour
    {
        #region Fields



        #endregion


        #region UnityMethods

        private void Awake()
        {
            Application.targetFrameRate = 60;
            QualitySettings.SetQualityLevel(0);
            ScreenInterface.GetInstance().Execute(ScreenTypes.MainMenu);
            Screen.orientation = ScreenOrientation.Landscape;
        }

        #endregion


        #region Methods



        #endregion
    }
}