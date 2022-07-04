using UnityEngine;
using SideScroller.Model.Unit;
using SideScroller.Helpers.Managers;
using SideScroller.UI;
using SideScroller.UI.Types;

namespace SideScroller.Controller
{
    sealed class PlayerController : MonoBehaviour, IListenerScreen
    {
        #region Fields

        private BasePlayerCharacter _player;

        private bool _isActive;

        #endregion


        #region UnityMethods

        private void OnEnable()
        {
            GameMenu.Jump += Jump;
            GameMenu.Attack += Attack;
            GameMenu.Interact += Interacte;

            GameMenu.LeftArrowBool += MoveLeftBool;
            GameMenu.RightArrowBool += MoveRightBool;
        }

        private void OnDisable()
        {
            GameMenu.Jump -= Jump;
            GameMenu.Attack -= Attack;
            GameMenu.Interact -= Interacte;

            GameMenu.LeftArrowBool -= MoveLeftBool;
            GameMenu.RightArrowBool -= MoveRightBool;
        }

        private void Awake()
        {
            _player = GetComponent<BasePlayerCharacter>();

            ScreenInterface.GetInstance().AddObserver(ScreenTypes.GameMenu, this);
        }

        private void FixedUpdate()
        {
#if UNITY_EDITOR
            Vector2 inputAxis;
            inputAxis.x = Input.GetAxis(AxisManager.HORIZONTAL);

            if (inputAxis.x != 0)
            {
                _player.Movement.Move(inputAxis.x);
            }
            else
            {
                _player.Movement.Stop();
            }
#endif
        }

        #endregion


        #region Methods

        private void MoveLeftBool(bool isPress)
        {
            if (isPress)
            {
                _player.Movement.Move(-1f);
            }
            else if(!isPress)
            {
                _player.Movement.Stop();
            }
        }
        private void MoveRightBool(bool isPress)
        {
            if (isPress)
            {
                _player.Movement.Move(1f);
            }
            else if (!isPress)
            {
                _player.Movement.Stop();
            }
        }
        private void Attack()
        {
            _player.Combat.BegginAttack();
        }

        private void Jump()
        {
            _player.Movement.Jump();
        }
        private void Interacte()
        {
            if (_player.Interact.IsInteractPresent())
            {
                _player.Interact.InteractWithObjects();
            }
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
