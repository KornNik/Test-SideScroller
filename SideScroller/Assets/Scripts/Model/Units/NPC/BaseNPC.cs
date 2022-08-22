using UnityEngine;
using SideScroller.Data.Unit.AI;
using SideScroller.Model.Unit.AI;
using SideScroller.UI.Parts;

namespace SideScroller.Model.Unit
{
    abstract class BaseNPC : BaseUnit
    {
        #region Fields

        [SerializeField] protected AIParameters _AIParameters;

        protected NPCAI _NPCBrains;
        protected HealthBar _healthBar;
        protected Vector3 _patrolPoint;

        #endregion


        #region Properties

        public AIParameters AIParameters => _AIParameters;
        public Vector3 PatrolPoint => _patrolPoint;

        #endregion


        #region UnityMethods

        protected override void Awake()
        {
            base.Awake();
            _patrolPoint = SpawnPosition;
            _healthBar = GetComponentInChildren<HealthBar>();
            _healthBar.SetUnit(this);
        }

        protected override void Update()
        {
            base.Update();
            _NPCBrains.DoAI();
        }
        #endregion
    }
}
