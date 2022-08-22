using UnityEngine;
using SideScroller.Data.Unit;

namespace SideScroller.Model.Unit.Movement
{
    class PlayerMovement : BaseMovement
    {
        #region Fields


        #endregion


        #region ClassLifeCycle

        public PlayerMovement(BaseMovementParameters movementParameters, BaseUnit unitBehavior)
            : base(movementParameters, unitBehavior)
        {
            _movementParameters = movementParameters;
            _unitBehaviour = unitBehavior;
        }

        #endregion


        #region Methods

        public override void Move(float inputMoveementX, float inputMovementY)
        {
            base.Move(inputMoveementX, inputMovementY);
            if (_unitBehaviour.UnitBoolStates.IsGrounded)
            {
                var inputMovement = inputMoveementX * _movementParameters.MovingSpeed.BaseValue * Time.fixedDeltaTime;
                Vector2 directionMovement = new Vector2(inputMovement, 0);
                _unitBehaviour.transform.Translate(directionMovement, Space.World);
            }
            else if (!_unitBehaviour.UnitBoolStates.IsGrounded)
            {
                var inputMovement = inputMoveementX * _movementParameters.MovingSpeed.BaseValue * Time.fixedDeltaTime;
                Vector2 directionMovement = new Vector2(inputMovement, 0);
                _unitBehaviour.transform.Translate(directionMovement *
                    _unitBehaviour.UnitMovementParameters.InAirSpeedMovementMultiplier, Space.World);
            }
        }
        public override void Jump()
        {
            if (_unitBehaviour.UnitBoolStates.IsGrounded)
            {
                base.Jump();
                float jumpForce = Mathf.Sqrt(_movementParameters.JumpHeght.BaseValue * -2f *
                    (Physics2D.gravity.y * _unitBehaviour.UnitRigidbody.gravityScale));
                _unitBehaviour.UnitRigidbody.AddForce(new Vector2(_unitBehaviour.UnitBoolStates.IsMoving ?
                    _unitBehaviour.transform.right.x * _unitBehaviour.UnitMovementParameters.JumpingDirectionMovementMultiplier *
                    jumpForce : 0f, jumpForce), ForceMode2D.Force);
            }
        }
        protected override void FlipUnit(float movingInput)
        {
            base.FlipUnit(movingInput);
        }

        #endregion
    }
}