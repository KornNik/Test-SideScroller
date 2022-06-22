using UnityEngine;
using System.Collections;
using SideScroller.Data.Unit;
using SideScroller.Model.Item;

namespace SideScroller.Model.Unit.Combat
{
    abstract class BaseCombat : ICombat
    {
        #region Fields

        protected BaseUnit _unitBehaviour;
        protected BaseCombatParameters _combatParameters;

        protected float _weaponTimer;
        protected bool _isReady = true;
        protected Collider2D[] _damagingObjects;
        protected Vector2 _attackArea;

        private Coroutine _weaponTimerCoroutine;

        #endregion


        #region ClassLifeCycle

        public BaseCombat(BaseCombatParameters unitCombatParameters,BaseUnit unitBehaviour)
        {
            _combatParameters = unitCombatParameters;
            _unitBehaviour = unitBehaviour;
            _weaponTimer = _combatParameters.RechargeTime.BaseValue;
            _damagingObjects = new Collider2D[32];
        }

        #endregion


        #region Methods

        public virtual void BegginAttack()
        {
            if (!_isReady) return;
            if (!(_unitBehaviour.Equipment.Weapon is Weapon)) return;

            _unitBehaviour.UnitEventManager.Attack?.Invoke();
            _isReady = false;

            if (_weaponTimerCoroutine == null)
            {
                _weaponTimerCoroutine = _unitBehaviour.StartCoroutine(WeaponTimer());
            }
        }
        public void SetWeaponReadiness()
        {
            _isReady = true;
        }


        #endregion


        #region ICombat

        public virtual void AttackOnEventAnimation()
        {

        }
        public virtual void Protect()
        {

        }
        public virtual void Dodge()
        {

        }

        #endregion


        #region IEnumerator

        private IEnumerator WeaponTimer()
        {
            yield return new WaitForSeconds(_weaponTimer);
            SetWeaponReadiness();
            _weaponTimerCoroutine = null;
        }

        #endregion
    }
}