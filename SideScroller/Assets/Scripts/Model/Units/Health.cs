using System;
using SideScroller.Data.Unit;

namespace SideScroller.Model.Unit
{
    class Health
    {
        #region Fields

        public Action<float> HealthParametersChanged;

        private float _currentHealth;

        private BaseUnitParameters _unitParameters;

        #endregion


        #region Properties

        public float CurrentHealth { get { return _currentHealth; } private set { _currentHealth = value; HealthParametersChanged?.Invoke(GetHealthRate()); } }

        #endregion


        #region ClassLifeCycle

        public Health(BaseUnitParameters unitParameters)
        {
            _unitParameters = unitParameters;
            _currentHealth = _unitParameters.MaxHealth.BaseValue;
        }

        #endregion


        #region Methods

        public virtual void TakeDamage(float damage)
        {
            damage *= _unitParameters.Armor.BaseValue / 10;
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
            if (CurrentHealth > _unitParameters.MaxHealth.BaseValue)
            {
                CurrentHealth = _unitParameters.MaxHealth.BaseValue;
            }
        }

        public void SetHealthRate(float rate)
        {
            CurrentHealth = rate == 0 ? 0 : (int)(_unitParameters.MaxHealth.BaseValue / rate);
        }
        public float GetHealthRate()
        {
            return CurrentHealth == 0 ? 0 : (CurrentHealth / _unitParameters.MaxHealth.BaseValue);
        }

        public void SetHealthToMax()
        {
            if (CurrentHealth == 0)
            {
                AddHealth(_unitParameters.MaxHealth.BaseValue);
            }
        }

        #endregion
    }
}
