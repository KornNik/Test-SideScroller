using UnityEngine;
using SideScroller.Data.Level;
using SideScroller.Model.Unit;
using System.Collections.Generic;

namespace SideScroller.Model.LevelModel
{
    class Level : MonoBehaviour
    {
        #region Fields

        [SerializeField] private LevelParameters _levelData;
        [SerializeField] private Transform[] _enemiesSpawnTransform;

        private List<BaseNPC> _NPCsList;

        #endregion


        #region Properties

        public LevelParameters LevelData => _levelData;
        public List<BaseNPC> NPCList => _NPCsList;
        public Transform[] EnemiesSpawnTransform => _enemiesSpawnTransform;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _NPCsList = new List<BaseNPC>();
        }

        #endregion
    }
}