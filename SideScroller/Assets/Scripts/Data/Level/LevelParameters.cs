using UnityEngine;
using SideScroller.Helpers.Types;

namespace SideScroller.Data.Level
{
    [CreateAssetMenu(fileName = "LevelParameters", menuName = "Data/Level/LevelParameters")]
    class LevelParameters : ScriptableObject
    {
        #region Fields

        [SerializeField] private Vector3 _playerPosition;
        [SerializeField] private Vector3[] _NPCPositions;
        [SerializeField] private NPCTypes[] _NPCTypesArray;

        #endregion


        #region Properties

        public Vector3 PlayerPosition => _playerPosition;
        public Vector3[] NPCPositions => _NPCPositions;
        public NPCTypes[] NPCTypesArray => _NPCTypesArray;

        #endregion

    }
}