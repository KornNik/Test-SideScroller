using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace SideScroller.UI.Parts
{
    class ControlButton : Button
    {
        #region Fields

        public Action ButtonPress;

        private Coroutine _pressButtonCoroutine;

        private bool _isButtonDown;

        #endregion


        #region UnityMethods

        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);

            _isButtonDown = true;

            if (!(_pressButtonCoroutine is Coroutine))
            {
                _pressButtonCoroutine = StartCoroutine(ButtonPressingCoroutine());
            }
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);

            _isButtonDown = false;
        }

        #endregion


        #region IEnumeretor

        private IEnumerator ButtonPressingCoroutine()
        {
            while (_isButtonDown)
            {
                ButtonPress?.Invoke();
                yield return new WaitForFixedUpdate();
            }
            _pressButtonCoroutine = null;
        }

        #endregion
    }
}
