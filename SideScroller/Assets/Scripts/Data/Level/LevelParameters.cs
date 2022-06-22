using UnityEngine;
using SideScroller.Helpers.Types;

namespace SideScroller.Data.Level
{
    [CreateAssetMenu(fileName ="LevelParameters", menuName ="Data/Level/LevelParameters")]
    class LevelParameters : ScriptableObject
    {
        #region Fields

        [SerializeField] private int _enemyCount;
        [SerializeField] private NPCTypes[] _enemyTypesArray;

        #endregion


        #region Properties

        public int EnemyCount => _enemyCount;
        public NPCTypes[] EnemyTypesArray => _enemyTypesArray;

        #endregion


        #region UnityMethods

        private void OnEnable()
        {
        }

        #endregion
    }
}