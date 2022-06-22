using System;
using UnityEngine;
using SideScroller.Helpers;
using SideScroller.Helpers.AssetsPath;
using SideScroller.Helpers.Types;
using SideScroller.Model.CameraBeh;
using SideScroller.Model.Unit;
using SideScroller.Model.LevelModel;

namespace SideScroller.Controller
{
    class LevelController
    {
        #region Fields

        public static event Action<BasePlayerCharacter> OnPlayerLoaded;

        private Level _level;
        private CameraBehaviour _playerCamera;
        private BasePlayerCharacter _playerCharacter;

        #endregion


        #region Properties

        public Level Level => _level;
        public CameraBehaviour PlayerCamera => _playerCamera;
        public BasePlayerCharacter PlayerCharacter => _playerCharacter;

        #endregion


        #region UnityMethods

        public LevelController()
        {

        }

        #endregion


        #region Methods

        public Level LoadLevel(LevelTypes levelType)
        {
            var resources = CustomResources.Load<Level>(LevelsAssetPath.LevelsPath[levelType]);
            _level = UnityEngine.Object.Instantiate(resources, Vector3.zero, Quaternion.identity);

            return _level;
        }
        public BasePlayerCharacter LoadPlayer(PlayerCharacterTypes playerType)
        {
            _playerCharacter = new PlayerLoader().CreateHero(playerType).WithWeapon(WeaponType.Sword);
            OnPlayerLoaded?.Invoke(_playerCharacter);
            return _playerCharacter;
        }
        public CameraBehaviour LoadCamera(CameraTypes cameraType)
        {
            var resources = CustomResources.Load<CameraBehaviour>(CamerasAssetPath.CamerasPath[cameraType]);
            _playerCamera = UnityEngine.Object.Instantiate(resources, Vector3.zero, Quaternion.identity);
            return _playerCamera;
        }
        public BaseNPC LoadEnemy(NPCTypes NPCType, Vector3 position)
        {
            return new NPCLoader().CreateNPC(NPCType).WithWeapon(WeaponType.Sword).WithStartPosition(position);
        }

        #endregion

    }
}