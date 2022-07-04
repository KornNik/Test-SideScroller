using UnityEngine;
using UnityEngine.UI;
using SideScroller.Model.Unit;
using SideScroller.Helpers.Services;

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
            }
        }

        private void OnDisable()
        {
            if (_unit is BaseUnit)
            {
                _unit.UnitEventManager.HealthChanged -= HealthDisplay;
            }
        }

        #endregion


        #region Methods

        public void SetUnit(BaseUnit unit)
        {
            _unit = unit;
        }

        public void HealthDisplay(float healthRate)
        {
            _healthFilledImage.fillAmount = healthRate;
        }

        #endregion
    }
}
