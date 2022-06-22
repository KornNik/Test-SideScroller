using UnityEngine;
using SideScroller.Data.Unit;

namespace SideScroller.Model.Unit.Movement
{
    abstract class BaseMovement
    {
        #region Fields

        protected BaseMovementParameters _movementParameters;
        protected BaseUnit _unitBehaviour;

        protected Vector2 _inputAxis;
        protected bool _flipped;
        protected bool _isMoving;
        protected bool _isJumping;

        #endregion


        #region ClassLifeCycle

        public BaseMovement(BaseMovementParameters movementParameters, BaseUnit unitBehaviour)
        {
            _movementParameters = movementParameters;
            _unitBehaviour = unitBehaviour;
        }

        #endregion


        #region Methods

        public virtual void MovementCalculating()
        {
            if (_unitBehaviour.GroundCheck.IsGrounded && _isJumping)
            {
                _unitBehaviour.UnitRigidbody.velocity = Vector3.zero;
                _isJumping = false;
            }
        }

        public virtual void Move(float inputMovementX)
        {
            if (inputMovementX == 0)
            {
                if (_isMoving)
                {
                    _isMoving = false;
                    _unitBehaviour.UnitEventManager.Moving?.Invoke(false);
                }
            }
            else
            {
                FlipUnit(inputMovementX);
                if (!_isMoving)
                {
                    _isMoving = true;
                    _unitBehaviour.UnitEventManager.Moving?.Invoke(true);
                }
            }
        }
        public virtual void Jump()
        {
            _unitBehaviour.UnitEventManager.Jump?.Invoke();
            _isJumping = true;
        }

        protected virtual void FlipUnit(float movingInput)
        {
             _flipped = movingInput < 0;
            _unitBehaviour.transform.rotation = Quaternion.Euler(new Vector3(0f, _flipped ? 180 : 0f, 0f));
        }

        #endregion
    }
}
