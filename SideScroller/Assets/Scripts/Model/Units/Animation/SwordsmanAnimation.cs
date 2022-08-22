using UnityEngine;
using SideScroller.Helpers.Managers;

namespace SideScroller.Model.Unit.AnimationUnit
{
    class SwordsmanAnimation : UnitAnimation<Swordsman>
    {
        #region UnityMethods

        protected override void Awake()
        {
            base.Awake();
            _unitBehaviour = GetComponent<Swordsman>();

            _eventHandler.SetEvent(SwordsmanAnimationClipManager.ATTACK, 0.5f, nameof(OnWeaponDamaging));
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
