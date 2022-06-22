using UnityEngine;
using SideScroller.Helpers.Managers;
using SideScroller.Model.Unit;

namespace SideScroller.Helpers.Extensions
{
    partial class GroundCheck
    {
        #region MyRegion

        protected BaseUnit _unit;

        protected bool _isGrounded;

        #endregion


        #region Properties

        public bool IsGrounded => _isGrounded;

        #endregion


        #region ClassLifeCycle

        public GroundCheck(BaseUnit unit)
        {
            _unit = unit;
        }

        #endregion


        #region MyRegion

        public void LandingCheck()
        {
            if (Physics2D.Raycast(_unit.GroundCheckCollider.transform.position, Vector2.down, 0.01f, LayersManager.Ground))
            {
                _isGrounded = true;
                _unit.UnitEventManager.Grounded?.Invoke(_isGrounded);
            }
            else
            {
                _isGrounded = false;
                _unit.UnitEventManager.Grounded?.Invoke(_isGrounded);
            }
        }

        #endregion
    }
}
