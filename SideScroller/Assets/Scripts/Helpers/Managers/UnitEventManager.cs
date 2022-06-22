using System;

namespace SideScroller.Helpers.Managers
{
    sealed class UnitEventManager
    {
        #region Fields

        public Action Jump;
        public Action Hurt;
        public Action Death;
        public Action Attack;
        public Action Recover;
        public Action<bool> Moving;
        public Action<bool> Grounded;
        public Action<bool> WeaponOut;
        public Action<float> MovingSpeed;

        #endregion

    }
}