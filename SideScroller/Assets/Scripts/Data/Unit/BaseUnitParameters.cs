using System;
using UnityEngine;
using SideScroller.Data.Parameter;

namespace SideScroller.Data.Unit
{
    abstract class BaseUnitParameters : ScriptableObject
    {
        #region Fields

        public Action<float> HealthParametersChanged;

        [SerializeField] protected Stat _maxHealth;
        [SerializeField] protected Stat _armor;
        [SerializeField] protected BaseMovementParameters _baseMovement;

        [SerializeField] protected float _currentHealth;
        [SerializeField] protected float _interactDistance;
        [SerializeField] protected float _invinsibleDuration;

        #endregion


        #region Properties

        public Stat MaxHealth => _maxHealth;
        public Stat Armor => _armor;
        public BaseMovementParameters BaseMovement => _baseMovement;

        public float InteractDistance => _interactDistance;
        public float CurrentHealth { get { return _currentHealth; } private set { _currentHealth = value; HealthParametersChanged?.Invoke(GetHealthRate()); } }

        #endregion


        #region UnityMethods

        private void OnEnable()
        {
            CurrentHealth = _maxHealth.BaseValue;
        }

        #endregion


        #region Methods

        public virtual void TakeDamage(float damage)
        {
            damage *= _armor.BaseValue / 10;
            if (damage > 0)
            {
                CurrentHealth -= damage;
                if (CurrentHealth <= 0)
                {
                    CurrentHealth = 0;
                }
            }
        }
        public void AddHealth(float amount)
        {
            CurrentHealth += amount;
            if (CurrentHealth > _maxHealth.BaseValue)
            {
                CurrentHealth = _maxHealth.BaseValue;
            }
        }

        public void SetHealthRate(float rate)
        {
            CurrentHealth = rate == 0 ? 0 : (int)(_maxHealth.BaseValue / rate);
        }
        public float GetHealthRate()
        {
            return CurrentHealth == 0 ? 0 : (CurrentHealth / _maxHealth.BaseValue);
        }

        public void SetHealthToMax()
        {
            if (CurrentHealth == 0)
            {
                AddHealth(_maxHealth.BaseValue);
            }
        }

        #endregion
    }
}
