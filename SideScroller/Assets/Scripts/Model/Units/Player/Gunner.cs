using SideScroller.Model.Unit.Combat;
using SideScroller.Model.Unit.Movement;

namespace SideScroller.Model.Unit
{
    class Gunner : BasePlayerCharacter
    {
        #region UnityMethods

        protected override void Awake()
        {
            base.Awake();
            _motionManager = new MotionManager(this, new PlayerMovement(UnitMovementParameters, this),
                new GunnerCombat(UnitCombatParameters, this));
        }

        #endregion
    }
}