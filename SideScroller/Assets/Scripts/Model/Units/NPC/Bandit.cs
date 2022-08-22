using UnityEngine;
using SideScroller.Model.Unit.Combat;
using SideScroller.Model.Unit.Movement;
using SideScroller.Model.Unit.AI;

namespace SideScroller.Model.Unit
{
    class Bandit : BaseNPC
    {
        #region UnityMethods

        protected override void Awake()
        {
            base.Awake();
            _motionManager = new MotionManager(this, new NPCMovement(UnitMovementParameters, this), new BanditCombat(UnitCombatParameters, this));
            _NPCBrains = new NPCAI(this, _AIParameters);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _AIParameters.DistanceView);
        }
        #endregion
    }
}