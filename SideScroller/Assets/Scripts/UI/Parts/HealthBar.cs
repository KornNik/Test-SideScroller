using UnityEngine;
using UnityEngine.UI;
using SideScroller.Model.Unit;

namespace SideScroller.UI.Parts
{
    class HealthBar : MonoBehaviour
    {

        #region Fields

        [SerializeField] private Image _healthFilledImage;

        private BaseUnit _unit;

        #endregion


        #region UnityMethods

        private void OnEnable()
        {
            if (_unit is BaseUnit)
            {
                _unit.UnitEventManager.HealthChanged += HealthDisplay;
                _unit.UnitEventManager.Death += HealthBarOff;
                _unit.UnitEventManager.Recover += HealthBarOn;
            }
        }

        private void OnDisable()
        {
            if (_unit is BaseUnit)
            {
                _unit.UnitEventManager.HealthChanged -= HealthDisplay;
                _unit.UnitEventManager.Death -= HealthBarOff;
                _unit.UnitEventManager.Recover -= HealthBarOn;
            }
        }

        #endregion


        #region Methods

        public void SetUnit(BaseUnit unit)
        {
            _unit = unit;
        }

        private void HealthDisplay(float healthRate)
        {
            _healthFilledImage.fillAmount = healthRate;
        }
        private void HealthBarOff()
        {
            gameObject.SetActive(false);
        }
        private void HealthBarOn()
        {
            gameObject.SetActive(true);
        }

        #endregion
    }
}
