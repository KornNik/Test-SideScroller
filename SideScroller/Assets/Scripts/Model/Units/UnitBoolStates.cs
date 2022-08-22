
namespace SideScroller.Model.Unit
{
    class UnitBoolStates
    {
        #region Fields

        private bool _isDead;
        private bool _isFlip;
        private bool _isMoving;
        private bool _isJumping;
        private bool _isVisible;
        private bool _isGrounded;
        private bool _isInvinsible;
        private bool _isColliderActive;

        #endregion


        #region Properties

        public bool IsDead { get { return _isDead; } set { _isDead = value; } }
        public bool IsFlip { get { return _isFlip; } set { _isFlip = value; } }
        public bool IsMoving { get { return _isMoving; } set { _isMoving = value; } }
        public bool IsJumping { get { return _isJumping; } set { _isJumping = value; } }
        public bool IsVisible { get { return _isVisible; } set { _isVisible = value; } }
        public bool IsGrounded { get { return _isGrounded; } set { _isGrounded = value; } }
        public bool IsInvinsible { get { return _isInvinsible; } set { _isInvinsible = value; } }
        public bool IsColliderActive { get { return _isColliderActive; } set { _isColliderActive = value; } }

        #endregion

    }
}