using SideScroller.Model.Unit.Combat;
using SideScroller.Model.Unit.Movement;
using SideScroller.Model.Unit.Interact;
using SideScroller.Helpers.Extensions;

namespace SideScroller.Model.Unit
{
    class MotionManager
    {
        #region Fields

        private BaseUnit _unit;
        private BaseCombat _combat;
        private BaseMovement _movement;
        private BaseInteract _interact;
        private GroundCheck _groundCheck;

        #endregion


        #region Properties

        public BaseCombat Combat => _combat;
        public BaseInteract Interact => _interact;
        public BaseMovement Movement => _movement;

        #endregion


        #region ClassLifeCycle

        public MotionManager(BaseUnit unit, BaseMovement movement, BaseCombat combat)
        {
            _unit = unit;
            _combat = combat;
            _movement = movement;
            _interact = new BaseInteract(unit);
            _groundCheck = new GroundCheck(unit);
        }

        #endregion


        #region Methods

        public void MovementUpdate()
        {
            _groundCheck.LandingCheck(_unit.GroundCheckCollider.transform.position);
        }

        #endregion
    }
}
