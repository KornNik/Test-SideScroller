using UnityEngine;
using SideScroller.Helpers.Managers;
using SideScroller.Model.Unit;

namespace SideScroller.Helpers.Extensions
{
    partial class GroundCheck
    {
        #region MyRegion

        private BaseUnit _unit;

        #endregion


        #region ClassLifeCycle

        public GroundCheck(BaseUnit unit)
        {
            _unit = unit;
        }

        #endregion


        #region MyRegion

        public void LandingCheck(Vector3 groundCheckColliderPosition)
        {
            if (Physics2D.Raycast(groundCheckColliderPosition, Vector2.down, 0.01f, LayersManager.Ground))
            {
                _unit.UnitBoolStates.IsGrounded = true;
                _unit.UnitEventManager.Grounded?.Invoke(_unit.UnitBoolStates.IsGrounded);
            }
            else
            {
                _unit.UnitBoolStates.IsGrounded = false;
                _unit.UnitEventManager.Grounded?.Invoke(_unit.UnitBoolStates.IsGrounded);
            }
        }

        #endregion
    }
}
