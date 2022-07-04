using UnityEngine;
using System.Collections;
using SideScroller.Data.Unit;

namespace SideScroller.Model.Unit.Movement
{
    abstract class BaseMovement
    {
        #region Fields

        protected BaseMovementParameters _movementParameters;
        protected BaseUnit _unitBehaviour;

        protected float _movementValue = 0f; 

        #endregion


        #region ClassLifeCycle

        public BaseMovement(BaseMovementParameters movementParameters, BaseUnit unitBehaviour)
        {
            _movementParameters = movementParameters;
            _unitBehaviour = unitBehaviour;
            _unitBehaviour.UnitEventManager.Grounded += VelocityLanding;
        }
        ~BaseMovement()
        {
            _unitBehaviour.UnitEventManager.Grounded -= VelocityLanding;
        }

        #endregion


        #region Methods

        public void MovementUpdate()
        {
            _unitBehaviour.GroundCheck.LandingCheck(_unitBehaviour.GroundCheckCollider.transform.position);
        }

        public virtual void Move(float inputMovementX)
        {
            FlipUnit(inputMovementX);
            _unitBehaviour.UnitBoolStates.IsMoving = true;
            _unitBehaviour.UnitEventManager.Moving?.Invoke(true);
        }
        public virtual void Stop()
        {
            _unitBehaviour.UnitBoolStates.IsMoving = false;
            _unitBehaviour.UnitEventManager.Moving?.Invoke(false);
        }
        public virtual void Jump()
        {
            _unitBehaviour.UnitEventManager.Jump?.Invoke();
            _unitBehaviour.UnitBoolStates.IsJumping = true;
        }
        protected virtual void FlipUnit(float movingInput)
        {
            _unitBehaviour.UnitBoolStates.IsFlip = movingInput < 0;
            _unitBehaviour.transform.rotation = Quaternion.Euler(new Vector3
                (0f, _unitBehaviour.UnitBoolStates.IsFlip ? 180 : 0f, 0f));
        }
        protected virtual void VelocityLanding(bool isGrounded)
        {
            if (isGrounded && _unitBehaviour.UnitBoolStates.IsJumping)
            {
                _unitBehaviour.UnitRigidbody.velocity = Vector3.zero;
                _unitBehaviour.UnitBoolStates.IsJumping = false;
            }
        }

        #endregion
    }
}
