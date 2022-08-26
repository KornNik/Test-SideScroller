using UnityEngine;
using SideScroller.UI;
using SideScroller.Data.Level;
using SideScroller.Model.LevelModel;

namespace SideScroller.Controller
{
    class LevelController : MonoBehaviour
    {
        #region Fields

        [SerializeField] private LevelsBundle _levelsBundle;

        private LevelLoader _levelLoader;
        private LevelsManager _levelsManager;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _levelLoader = new LevelLoader();
            _levelsManager = new LevelsManager(_levelsBundle, _levelLoader);
        }
        private void OnEnable()
        {
            SelectCharacterMenu.CharacterSelectType += _levelLoader.OnCharacterSelect;
        }

        private void OnDisable()
        {
            SelectCharacterMenu.CharacterSelectType -= _levelLoader.OnCharacterSelect;
        }

        #endregion

    }
}