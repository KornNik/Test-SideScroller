using UnityEngine;
using SideScroller.UI;
using SideScroller.UI.Types;
using SideScroller.Helpers.Types;
using SideScroller.Model.Unit;

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
            _levelController.LoadLevel(_levelType);
            _levelController.LoadCamera(_cameraType);
            LoadNPC();
        }

        private void LoadPlayer(PlayerCharacterTypes playerCharacterTypes)
        {
            _levelController.LoadPlayer(playerCharacterTypes);
            ScreenInterface.GetInstance().Execute(ScreenTypes.GameMenu);
        }
        private void LoadNPC()
        {
            for (int i = 0; i < _levelController.Level.LevelData.EnemyTypesArray.Length; i++)
            {
                var NPC = _levelController.LoadEnemy(_levelController.Level.LevelData.EnemyTypesArray[i],
                    _levelController.Level.EnemiesSpawnTransform[i].position);
                _levelController.Level.NPCList.Add(NPC);
            }
        }
        #endregion
    }
}