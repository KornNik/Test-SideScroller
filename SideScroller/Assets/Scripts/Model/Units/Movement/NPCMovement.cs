using UnityEngine;
using SideScroller.Data.Unit;

namespace SideScroller.Model.Unit.Movement
{
    class NPCMovement : BaseMovement
    {
        #region ClassLifeCycle

        public NPCMovement(BaseMovementParameters movementParameters, BaseUnit unitBehaviour)
            : base(movementParameters, unitBehaviour)
        {
            _movementParameters = movementParameters;
            _unitBehaviour = unitBehaviour;
        }

        #endregion


        #region Methods

        public override void Move(float inputMovementX, float inputMovementY)
        {
            base.Move(inputMovementX, inputMovementY);

            Vector3 directionSurface = _unitBehaviour.SurfaceSlider.Project(_unitBehaviour.transform.right);
            Vector3 offset = directionSurface * (_movementParameters.MovingSpeed.BaseValue * Time.fixedDeltaTime);
            _unitBehaviour.UnitRigidbody.MovePosition(_unitBehaviour.UnitRigidbody.position + new Vector2(offset.x, offset.y));
        }
        public override void Jump()
        {
            if (_unitBehaviour.UnitBoolStates.IsGrounded)
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