using UnityEngine;
using SideScroller.Data.Unit.AI;
using SideScroller.Model.Unit.Movement;
using SideScroller.Model.Unit.AI;

namespace SideScroller.Model.Unit
{
    abstract class BaseNPC : BaseUnit
    {
        #region Fields

        [SerializeField] protected AIParameters _AIParameters;

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
        }

        #endregion
    }
}
