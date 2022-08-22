using UnityEngine;
using SideScroller.Helpers;
using SideScroller.Helpers.Types;
using SideScroller.Helpers.Services;
using SideScroller.Helpers.AssetsPath;
using SideScroller.Model.Unit;
using SideScroller.Model.CameraBeh;
using SideScroller.Model.LevelModel;
using SideScroller.UI;
using SideScroller.UI.Types;

namespace SideScroller.Controller
{
    class LevelLoader
    {
        #region Fields

        private Level _level;
        private CameraBehaviour _playerCamera;
        private BasePlayerCharacter _playerCharacter;

        #endregion


        #region Properties

        public Level Level => _level;
        public CameraBehaviour PlayerCamera => _playerCamera;
        public BasePlayerCharacter PlayerCharacter => _playerCharacter;

        #endregion


        #region ClassLifeCycle

        public LevelLoader()
        {

        }

        #endregion


        #region Methods

        public void OnCharacterSelect(PlayerCharacterTypes playerType)
        {
            LoadPlayer(playerType);
        }

        public void Load(LevelTypes levelType)
        {
            LoadLevel(levelType);
            LoadCamera();
            if(_playerCharacter is BasePlayerCharacter)
            {
                _playerCharacter.transform.position = _level.PlayerSpawnPosition.position;
            }
        }
        private void LoadLevel(LevelTypes levelType)
        {
            if (_level==null)
            {
                var resources = CustomResources.Load<Level>(LevelsAssetPath.LevelsPath[levelType]);
                _level = Object.Instantiate(resources, Vector3.zero, Quaternion.identity);
                LoadNPC();
            }
            else if(_level != null)
            {
                ClearLvl();
                LoadLevel(levelType);
            }
        }
        private void LoadPlayer(PlayerCharacterTypes playerType)
        {
            if (_playerCharacter == null)
            {
                _playerCharacter = new PlayerLoader().CreateHero(playerType)
                    .WithStartPosition(_level.LevelData.PlayerPosition);
                Services.Instance.PlayerService.SetPlayer(_playerCharacter);
                _playerCamera.SetPlayer(_playerCharacter);
            }
            ScreenInterface.GetInstance().Execute(ScreenTypes.InventoryMenu);
        }
        private void LoadCamera()
        {
            if (_playerCamera == null)
            {
                var resources = CustomResources.Load<CameraBehaviour>(CamerasAssetPath.CamerasPath[CameraTypes.MainCamera]);
                _playerCamera = UnityEngine.Object.Instantiate(resources, Vector3.zero, Quaternion.identity);
            }
        }
        private void LoadNPC()
        {
            if (_level.LevelData.NPCTypesArray.Length <= 0) return;

            for (int i = 0; i < _level.LevelData.NPCTypesArray.Length; i++)
            {
                _level.NPCList.Add(new NPCLoader().CreateNPC(_level.LevelData.NPCTypesArray[i])
                    .WithWeapon(WeaponType.Sword).WithStartPosition(_level.LevelData.NPCPositions[i]));
            }
        }

        private void ClearLvl()
        {
            if (_level.NPCList.Count > 0)
            {
                foreach (var item in _level.NPCList)
                {
                    Object.Destroy(item.gameObject);
                }
                _level.NPCList.Clear();
            }

            Object.Destroy(_level.gameObject);
            _level = null;
        }
        #endregion
    }
}
