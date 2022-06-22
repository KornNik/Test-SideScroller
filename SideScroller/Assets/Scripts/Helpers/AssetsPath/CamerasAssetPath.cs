using System.Collections.Generic;
using SideScroller.Helpers.Types;

namespace SideScroller.Helpers.AssetsPath
{
    sealed class CamerasAssetPath
    {
        #region Fields

        public static Dictionary<CameraTypes, string> CamerasPath = new Dictionary<CameraTypes, string>
        {
            {CameraTypes.MainCamera,"Prefabs/Cameras/Prefabs_Cameras_MainCamera" },
        };

        #endregion
    }
}