using System;
using UnityEngine;
using SideScroller.Data.Level;
using SideScroller.Model.Unit;
using System.Collections.Generic;

namespace SideScroller.Model.LevelModel
{
    class Level : MonoBehaviour
    {
        #region Fields

        public Action LevelStarting;
        public Action LevelEnding;

        [SerializeField] private LevelParameters _levelData;
        [SerializeField] private Transform _playerSpawnPostion;
        [SerializeField] private Transform[] _enemiesSpawnTransform;
        [SerializeField] private LevelTrigger _levelTrigger;

        private List<BaseNPC> _NPCsList;

        #endregion


        #region Properties

        public List<BaseNPC> NPCList => _NPCsList;
        public LevelParameters LevelData => _levelData;
        public Transform PlayerSpawnPosition => _playerSpawnPostion;
        public Transform[] EnemiesSpawnTransform => _enemiesSpawnTransform;
        #endregion


        #region UnityMethods

        private void Awake()
        {
            _NPCsList = new List<BaseNPC>();
            LevelStarting?.Invoke();
        }

        private void OnEnable()
        {
            _levelTrigger.TriggerEntered += OnTriggerEndLevelEnter;
        }

        private void OnDisable()
        {
            _levelTrigger.TriggerEntered -= OnTriggerEndLevelEnter;
        }

        private void OnTriggerEndLevelEnter()
        {
            LevelEnding?.Invoke();

        }
        #endregion
    }
}