using UnityEngine;
using SideScroller.Data.Parameter;

namespace SideScroller.Data.Unit
{
    abstract class BaseUnitParameters : ScriptableObject
    {
        #region Fields

        [SerializeField] protected Stat _maxHealth;
        [SerializeField] protected Stat _armor;
        [SerializeField] protected BaseMovementParameters _baseMovement;

        [SerializeField] protected float _currentHealth;

        #endregion


        #region Properties

        public Stat MaxHealth => _maxHealth;
        public Stat Armor => _armor;
        public BaseMovementParameters BaseMovement => _baseMovement;
        public float CurrentHealth => _currentHealth;

        #endregion


        #region UnityMethods

        private void OnEnable()
        {
            _currentHealth = _maxHealth.BaseValue;
        }

        #endregion


        #region Methods

        public virtual void TakeDamage(float damage)
        {
            damage *= _armor.BaseValue / 100;
            if (damage > 0)
            {
                _currentHealth -= damage;
                if (_currentHealth <= 0)
                {
                    _currentHealth = 0;
                }
            }
        }
        public void AddHealth(int amount)
        {
            _currentHealth += amount;
            if (_currentHealth > _maxHealth.BaseValue)
            {
                _currentHealth = _maxHealth.BaseValue;
            }
        }

        public void SetHealthRate(float rate)
        {
            _currentHealth = rate == 0 ? 0 : (int)(_maxHealth.BaseValue / rate);
        }

        public void SetHealthToMax()
        {
            if (_currentHealth == 0)
            {
                _currentHealth = _maxHealth.BaseValue;
            }
        }

        #endregion
    }
}
