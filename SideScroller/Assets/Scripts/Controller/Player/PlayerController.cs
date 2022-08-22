using UnityEngine;
using SideScroller.Model.Unit;
using SideScroller.UI;
using SideScroller.UI.Types;
using SideScroller.Model.Inputs;

namespace SideScroller.Controller
{
    sealed class PlayerController : MonoBehaviour, IListenerScreen
    {
        #region Fields

        private BasePlayerCharacter _player;
        private BaseInputs _playerInput;

        private bool _isActive;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _player = GetComponent<BasePlayerCharacter>();

            _playerInput = new CommonInput(_player);

            ScreenInterface.GetInstance().AddObserver(ScreenTypes.GameMenu, this);
        }

        #endregion


        #region IListnerScreen
        public void ShowScreen()
        {
            _isActive = true;
        }

        public void HideScreen()
        {
            _isActive = false;
        }

        #endregion
    }
}
