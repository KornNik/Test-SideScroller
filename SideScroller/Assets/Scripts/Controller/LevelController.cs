using System;
using UnityEngine;
using SideScroller.Helpers;
using SideScroller.Model.Unit;
using SideScroller.Helpers.Types;
using SideScroller.Model.CameraBeh;
using SideScroller.Model.LevelModel;
using SideScroller.Helpers.Services;
using SideScroller.Helpers.AssetsPath;

namespace SideScroller.Controller
{
    class LevelController
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


        #region Methods

        public void  LoadLevel(LevelTypes levelType)
        {
            var resources = CustomResources.Load<Level>(LevelsAssetPath.LevelsPath[levelType]);
            _level = UnityEngine.Object.Instantiate(resources, Vector3.zero, Quaternion.identity);
        }
        public void LoadPlayer(PlayerCharacterTypes playerType)
        {
            _playerCharacter = new PlayerLoader().CreateHero(playerType).WithWeapon(WeaponType.Sword);
            Services.Instance.PlayerService.SetPlayer(_playerCharacter);
            _playerCamera.SetPlayer(_playerCharacter);
        }
        public void LoadCamera(CameraTypes cameraType)
        {
            var resources = CustomResources.Load<CameraBehaviour>(CamerasAssetPath.CamerasPath[cameraType]);
            _playerCamera = UnityEngine.Object.Instantiate(resources, Vector3.zero, Quaternion.identity);
        }
        public void LoadNPC()
        {
            for (int i = 0; i < _level.LevelData.NPCTypesArray.Length; i++)
            {
                _level.NPCList.Add(new NPCLoader().CreateNPC(_level.LevelData.NPCTypesArray[i])
                    .WithWeapon(WeaponType.Sword).WithStartPosition(_level.LevelData.NPCPositions[i]));
            }
        }

        #endregion

    }
}