using UnityEngine;
using SideScroller.Data.Unit;
using SideScroller.Helpers.Managers;
using SideScroller.Model.Item;

namespace SideScroller.Model.Unit.Combat
{
    class SwordsmanCombat : BaseCombat
    {

        #region ClassLifeCycle

        public SwordsmanCombat(BaseCombatParameters unitCombatParameters, BaseUnit unitBehaviour) : base(unitCombatParameters, unitBehaviour)
        {
            _combatParameters = unitCombatParameters;
            _unitBehaviour = unitBehaviour;
        }

        #endregion


        #region Methods


        #endregion


        #region ICombat

        public override void AttackOnEventAnimation()
        {
            base.AttackOnEventAnimation();
            var result = Physics2D.OverlapCircleNonAlloc(_unitBehaviour.AttackArea.position, 0.2f, _damagingObjects, LayersManager.EnemyLayer);
            for (int i = 0; i < result; i++)
            {
                var victim = _damagingObjects[i].GetComponent<IDamageable>();
                if (victim != null)
                {
                    _unitBehaviour.UnitBags.Equipment.Weapon.WeaponAttack(victim);
                }
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