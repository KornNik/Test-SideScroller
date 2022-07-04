using UnityEngine;
using SideScroller.Helpers.Types;

namespace SideScroller.Data.Level
{
    [CreateAssetMenu(fileName = "LevelParameters", menuName = "Data/Level/LevelParameters")]
    class LevelParameters : ScriptableObject
    {
        #region Fields

        [SerializeField] private int _enemyCount;
        [SerializeField] private NPCTypes[] _NPCTypesArray;
        [SerializeField] private Vector3[] _NPCPositions;

        #endregion


        #region Properties

        public int EnemyCount => _enemyCount;
        public NPCTypes[] NPCTypesArray => _NPCTypesArray;
        public Vector3[] NPCPositions => _NPCPositions;

        #endregion

    }
}