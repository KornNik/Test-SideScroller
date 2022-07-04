using UnityEngine;
using SideScroller.Data.Unit.AI;
using SideScroller.Model.Unit.Movement;
using SideScroller.Model.Unit.AI;
using SideScroller.UI.Parts;

namespace SideScroller.Model.Unit
{
    abstract class BaseNPC : BaseUnit
    {
        #region Fields

        [SerializeField] protected AIParameters _AIParameters;
        [SerializeField] protected HealthBar _healthBar;

        protected NPCAI _NPCBrains;

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
            _movement = new NPCMovement(_unitMovementParameters, this);
            _patrolPoint = transform.position;
            _healthBar = GetComponentInChildren<HealthBar>();
            _healthBar.SetUnit(this);
        }

        #endregion
    }
}
