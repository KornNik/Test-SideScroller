using UnityEngine;
using UnityEngine.UI;

namespace SideScroller.UI.Parts
{
    class HealthBar : MonoBehaviour
    {

        #region Fields

        [SerializeField]private Image _healthFilledImage;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _healthFilledImage = GetComponentInChildren<Image>();
        }

        #endregion


        #region Methods

        public void HealthDisplay(float healthRate)
        {
            _healthFilledImage.fillAmount = healthRate;
        }

        #endregion
    }
}
