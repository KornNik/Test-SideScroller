using UnityEngine;
using SideScroller.Helpers.Managers;

namespace SideScroller.Model.Unit.AnimationUnit
{
    class GunnerAnimation : UnitAnimation<Gunner>
    {
        #region UnityMethods

        protected override void Awake()
        {
            base.Awake();
            _unitBehaviour = GetComponentInParent<Gunner>();

            _eventHandler.SetEvent(GunnerAnimationClipManager.ATTACK, 0.5f, nameof(OnWeaponDamaging));
        }

        #endregion


        #region Methods

        private void OnWeaponDamaging()
        {
            _unitBehaviour.MotionManager.Combat.AttackOnEventAnimation();
        }

        #endregion
    }
}
