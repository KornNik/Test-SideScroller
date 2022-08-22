using UnityEngine;
using SideScroller.Helpers.Types;

namespace SideScroller.Data.Level
{
    [CreateAssetMenu(fileName = "LevelsBundle", menuName = "Data/Level/LevelsBundle")]
    sealed class LevelsBundle : ScriptableObject
    {
        #region Fields

        [SerializeField] private LevelTypes[] _levels;

        private LevelTypes _currentLevel;

        #endregion


        #region Properties

        public LevelTypes[] Levels=> _levels;
        public LevelTypes CurrentLevel => _currentLevel;
        public LevelTypes this[int index] { get { _currentLevel = Levels[index]; return Levels[index]; } }

        #endregion

        #region UnityMethods

        private void OnDisable()
        {
            _currentLevel = _levels[0];
        }

        #endregion
    }
}
