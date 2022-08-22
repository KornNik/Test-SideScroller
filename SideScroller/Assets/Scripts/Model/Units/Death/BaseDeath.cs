using SideScroller.Helpers;

namespace SideScroller.Model.Unit.Death
{
    class BaseDeath
    {
        #region Fields

        private BaseUnit _unit;

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
            _unit.UnitRigidbody.simulated = false;
            _unit.UnitBoolStates.IsDead = true;
        }
        public void Recover()
        {
            RenderVisibility.SpriteRenderVisibilityChange(_unit.transform, _unit.UnitSprite, true);
            ColliderEnabler.ColliderEnabledChanger(_unit.transform, _unit.UnitCollider, true);
            _unit.UnitRigidbody.simulated = true;
            _unit.UnitBoolStates.IsDead = false;
            _unit.transform.position = _unit.SpawnPosition;
        }

        #endregion
    }
}
