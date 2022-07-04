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
        public Action<bool> IsButtonPressed;

        private Coroutine _pressButtonCoroutine;

        private bool _isButtonDown;

        #endregion


        #region Properties

        public bool IsButtonDown { get { return _isButtonDown; } private set { _isButtonDown = value; IsButtonPressed?.Invoke(_isButtonDown); } }

        #endregion


        #region UnityMethods

        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);

            IsButtonDown = true;

            if (!(_pressButtonCoroutine is Coroutine))
            {
                _pressButtonCoroutine = StartCoroutine(ButtonPressingCoroutine());
            }
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);

            IsButtonDown = false;
        }

        #endregion


        #region IEnumeretor

        private IEnumerator ButtonPressingCoroutine()
        {
            while (IsButtonDown)
            {
                IsButtonPressed?.Invoke(IsButtonDown);
                yield return new WaitForFixedUpdate();
            }
            _pressButtonCoroutine = null;
        }

        #endregion
    }
}
