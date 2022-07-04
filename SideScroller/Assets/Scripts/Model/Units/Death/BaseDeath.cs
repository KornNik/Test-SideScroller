using SideScroller.Helpers;

namespace SideScroller.Model.Unit.Death
{
    class BaseDeath
    {
        #region Fields

        private BaseUnit _unit;

        #endregion


        #region Properties


        #endregion


        #region ClassLifeCycle

        public BaseDeath(BaseUnit unit)
        {
            _unit = unit;

            _unit.UnitEventManager.Death += Dying;
            _unit.UnitEventManager.Recover += Recover;
        }

        ~BaseDeath()
        {
            _unit.UnitEventManager.Death -= Dying;
            _unit.UnitEventManager.Recover -= Recover;
        }

        #endregion


        #region Methods

        public void Dying()
        {
            RenderVisibility.SpriteRenderVisibilityChange(_unit.transform, _unit.UnitSprite, false);
            ColliderEnabler.ColliderEnabledChanger(_unit.transform, _unit.UnitCollider, false);
            _unit.UnitRigidbody.isKinematic = true;
        }
        public void Recover()
        {
            RenderVisibility.SpriteRenderVisibilityChange(_unit.transform, _unit.UnitSprite, false);
            ColliderEnabler.ColliderEnabledChanger(_unit.transform, _unit.UnitCollider, false);
            _unit.UnitRigidbody.isKinematic = false;
        }

        #endregion
    }
}
