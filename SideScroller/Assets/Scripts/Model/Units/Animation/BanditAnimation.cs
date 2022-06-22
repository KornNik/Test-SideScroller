using SideScroller.Helpers.Managers;

namespace SideScroller.Model.Unit.AnimationUnit
{
    class BanditAnimation : UnitAnimation<Bandit>
    {
        #region Fields


        #endregion


        #region UnityMethods

        protected override void Awake()
        {
            base.Awake();
            _unitBehaviour = GetComponent<Bandit>();

            _eventHandler.SetEvent(BanditAnimationClipManager.ATTACK, 0.5f, nameof(OnWeaponDamaging));
        }

        #endregion


        #region Methods

        private void OnWeaponDamaging()
        {
            _unitBehaviour.Combat.AttackOnEventAnimation();
        }

        #endregion

    }
}
