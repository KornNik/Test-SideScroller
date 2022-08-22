using SideScroller.Data.Level;
using SideScroller.Helpers.Types;
using SideScroller.Controller;
using SideScroller.Helpers.Services;

namespace SideScroller.Model.LevelModel
{
    class LevelsManager
    {
        #region Fields

        private LevelLoader _levelLoader;
        private LevelsBundle _levelsBundle;

        private int _currentLevelIndex = 0;

        #endregion


        #region ClassLifeCycle

        public LevelsManager(LevelsBundle levelsBundle, LevelLoader levelLoader)
        {
            _levelsBundle = levelsBundle;
            _levelLoader = levelLoader;

            _levelLoader.Load(GetLevelType());
            _levelLoader.Level.LevelEnding += NextLvl;
        }

        ~ LevelsManager()
        {
            _levelLoader.Level.LevelEnding -= NextLvl;
        }

        #endregion


        #region Methods

        public LevelTypes GetLevelType()
        {
            return _levelsBundle[_currentLevelIndex];
        }
        private void ReloadLvl(Level level)
        {
            foreach (var item in level.NPCList)
            {
                item.UnitEventManager.Recover?.Invoke();
            }
            Services.Instance.PlayerService.PlayerCharacter.UnitEventManager.Recover?.Invoke();
        }
        public void NextLvl()
        {
            if (_levelsBundle.Levels.Length > _currentLevelIndex + 1)
            {
                _currentLevelIndex++;
                _levelLoader.Load(GetLevelType());
            }
        }

        #endregion
    }
}
