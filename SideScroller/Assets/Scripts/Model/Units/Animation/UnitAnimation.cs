using UnityEngine;
using SideScroller.Model.Unit;
using SideScroller.Helpers.Managers;

namespace SideScroller.Model.Unit.AnimationUnit
{
    [RequireComponent(typeof(Animator))]
    abstract class UnitAnimation<T> : MonoBehaviour 
        where T : BaseUnit
    {
        #region Fields

        [SerializeField] protected T _unitBehaviour;
        [SerializeField] protected Animator _unitAnimator;

        protected AnimationEventHandler _eventHandler;

        protected static readonly int _hurt = Animator.StringToHash(UnitAnimationParametersManager.HURT);
        protected static readonly int _jump = Animator.StringToHash(UnitAnimationParametersManager.JUMP);
        protected static readonly int _death = Animator.StringToHash(UnitAnimationParametersManager.DEATH);
        protected static readonly int _attack = Animator.StringToHash(UnitAnimationParametersManager.ATTACK);
        protected static readonly int _recover = Animator.StringToHash(UnitAnimationParametersManager.RECOVER);
        protected static readonly int _movingSpeed = Animator.StringToHash(UnitAnimationParametersManager.MOVING_SPEED);

        protected static readonly int _moving = Animator.StringToHash(UnitAnimationParametersManager.IS_MOVING);
        protected static readonly int _grounded = Animator.StringToHash(UnitAnimationParametersManager.IS_GROUNDED);
        protected static readonly int _weaponOut = Animator.StringToHash(UnitAnimationParametersManager.IS_WEAPON_OUT);

        #endregion


        #region UnityMethods

        private void OnEnable()
        {
            _unitBehaviour.UnitEventManager.Hurt += OnHurt;
            _unitBehaviour.UnitEventManager.Jump += OnJump;
            _unitBehaviour.UnitEventManager.Death += OnDeath;
            _unitBehaviour.UnitEventManager.Attack += OnAttack;
            _unitBehaviour.UnitEventManager.Recover += OnRecover;
            _unitBehaviour.UnitEventManager.Grounded += OnGrounded;
            _unitBehaviour.UnitEventManager.MovingSpeed += OnMoving;
            _unitBehaviour.UnitEventManager.WeaponOut += OnWeaponOut;

            _unitBehaviour.UnitEventManager.Moving += OnMovingBool;
        }

        private void OnDisable()
        {
            _unitBehaviour.UnitEventManager.Hurt -= OnHurt;
            _unitBehaviour.UnitEventManager.Jump -= OnJump;
            _unitBehaviour.UnitEventManager.Death -= OnDeath;
            _unitBehaviour.UnitEventManager.Attack -= OnAttack;
            _unitBehaviour.UnitEventManager.Recover -= OnRecover;
            _unitBehaviour.UnitEventManager.Grounded -= OnGrounded;
            _unitBehaviour.UnitEventManager.MovingSpeed -= OnMoving;
            _unitBehaviour.UnitEventManager.WeaponOut -= OnWeaponOut;

            _unitBehaviour.UnitEventManager.Moving -= OnMovingBool;
        }

        protected virtual void Awake()
        {
            _unitAnimator = GetComponent<Animator>();
            _eventHandler = new AnimationEventHandler(_unitAnimator);
        }

        #endregion


        #region Methods

        protected virtual void OnHurt()
        {
            _unitAnimator.SetTrigger(_hurt);
        } 
        protected virtual void OnJump()
        {
            _unitAnimator.SetTrigger(_jump);
        }
        protected virtual void OnDeath() 
        {
            _unitAnimator.SetTrigger(_death);
        }
        protected virtual void OnAttack()
        {
            _unitAnimator.SetTrigger(_attack);
        }
        protected virtual void OnRecover()
        {
            _unitAnimator.SetTrigger(_recover);
        }
        protected virtual void OnGrounded(bool isGrounded)
        {
            _unitAnimator.SetBool(_grounded, isGrounded);
        }
        protected virtual void OnWeaponOut(bool isWeaponOut)
        {
            _unitAnimator.SetBool(_weaponOut, isWeaponOut);
        }
        protected virtual void OnMoving(float movingSpeed)
        {
            _unitAnimator.SetFloat(_movingSpeed, movingSpeed);
        }
        protected virtual void OnMovingBool(bool isMoving)
        {
            _unitAnimator.SetBool(_moving, isMoving);
        }

        #endregion
    }
}