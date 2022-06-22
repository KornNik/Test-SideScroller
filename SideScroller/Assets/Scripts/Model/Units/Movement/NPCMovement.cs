using UnityEngine;
using SideScroller.Data.Unit;

namespace SideScroller.Model.Unit.Movement
{
    class NPCMovement : BaseMovement
    {
        #region Fields


        #endregion


        #region ClassLifeCycle

        public NPCMovement(BaseMovementParameters movementParameters, BaseUnit unitBehaviour)
            : base(movementParameters, unitBehaviour)
        {
            _movementParameters = movementParameters;
            _unitBehaviour = unitBehaviour;
        }

        #endregion


        #region Methods

        public override void Move(float inputMovementX)
        {
            base.Move(inputMovementX);

            var inputMovement = inputMovementX * _movementParameters.MovingSpeed.BaseValue * Time.fixedDeltaTime;
            Vector2 directionMovement = new Vector2(inputMovement, 0);
            _unitBehaviour.transform.Translate(directionMovement, Space.World);
        }
        public override void Jump()
        {
            if (_unitBehaviour.GroundCheck.IsGrounded)
            {
                base.Jump();
                float jumpForce = Mathf.Sqrt(_movementParameters.JumpHeght.BaseValue * -2 * (Physics2D.gravity.y * _unitBehaviour.UnitRigidbody.gravityScale));
                _unitBehaviour.UnitRigidbody.AddForce(new Vector2(_unitBehaviour.transform.right.x * jumpForce, jumpForce), ForceMode2D.Impulse);
            }
        }
        protected override void FlipUnit(float movingInput)
        {
            base.FlipUnit(movingInput);
        }

        #endregion
    }
}