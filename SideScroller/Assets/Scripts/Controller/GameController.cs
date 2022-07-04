using UnityEngine;
using SideScroller.UI;
using SideScroller.UI.Types;
using SideScroller.Helpers.Types;

namespace SideScroller.Controller
{
    class GameController : MonoBehaviour
    {
        #region Fields

        [SerializeField] private LevelTypes _levelType = LevelTypes.Forest;
        [SerializeField] private CameraTypes _cameraType = CameraTypes.MainCamera;

        private LevelController _levelController;

        #endregion


        #region Properties


        #endregion


        #region UnityMethods

        private void Awake()
        {
            Application.targetFrameRate = 60;
            QualitySettings.SetQualityLevel(0);
            ScreenInterface.GetInstance().Execute(ScreenTypes.MainMenu);

            _levelController = new LevelController();

            Load();
        }
        private void OnEnable()
        {
            SelectCharacterMenu.CharacterSelectType += LoadPlayer;
        }

        private void OnDisable()
        {
            SelectCharacterMenu.CharacterSelectType -= LoadPlayer;
        }

        #endregion


        #region Methods

        private void Load()
        {
            _levelController.LoadCamera(_cameraType);
            _levelController.LoadLevel(_levelType);
            _levelController.LoadNPC();
        }

        private void LoadPlayer(PlayerCharacterTypes playerCharacterTypes)
        {
            _levelController.LoadPlayer(playerCharacterTypes);
            ScreenInterface.GetInstance().Execute(ScreenTypes.InventoryMenu);
        }
        #endregion
    }
}