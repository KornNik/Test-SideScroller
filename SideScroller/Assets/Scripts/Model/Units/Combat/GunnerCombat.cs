using UnityEngine;
using SideScroller.Data.Unit;
using SideScroller.Helpers.Managers;
using SideScroller.Model.Item;

namespace SideScroller.Model.Unit.Combat
{
    class GunnerCombat : BaseCombat
    {

        #region ClassLifeCycle

        public GunnerCombat(BaseCombatParameters unitCombatParameters, BaseUnit unitBehaviour) : base(unitCombatParameters, unitBehaviour)
        {
            _combatParameters = unitCombatParameters;
            _unitBehaviour = unitBehaviour;
        }

        #endregion


        #region ICombat

        public override void AttackOnEventAnimation()
        {
            base.AttackOnEventAnimation();
            if(_unitBehaviour.UnitBags.Equipment.Weapon is CommonRangedWeapon)
            {
                _unitBehaviour.UnitBags.Equipment.Weapon.WeaponAttack();
            }
        }
        public override void Protect()
        {
            throw new System.NotImplementedException();
        }
        public override void Dodge()
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
