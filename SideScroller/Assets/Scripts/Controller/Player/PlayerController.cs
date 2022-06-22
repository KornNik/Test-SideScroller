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
            GameMenu.LeftArrow += MoveLeft;
            GameMenu.RightArrow += MoveRight;
        }

        private void OnDisable()
        {
            GameMenu.Jump -= Jump;
            GameMenu.Attack -= Attack;
            GameMenu.Interact -= Interacte;
            GameMenu.LeftArrow -= MoveLeft;
            GameMenu.RightArrow -= MoveRight;
        }

        private void Awake()
        {
            _player = GetComponent<BasePlayerCharacter>();

            ScreenInterface.GetInstance().AddObserver(ScreenTypes.GameMenu, this);
        }

        private void FixedUpdate()
        {
            if (!_isActive) return;

            Vector2 inputAxis;
            inputAxis.x = Input.GetAxis(AxisManager.HORIZONTAL);

            _player.Movement.Move(inputAxis.x);

            //if (Input.GetKeyDown(KeyManager.JUMP))
            //{
            //    _player.Movement.Jump();
            //}
            //if (Input.GetKeyDown(KeyManager.ATTACK))
            //{
            //    _player.Combat.BegginAttack();
            //}
            //if (_player.IsInteractePresent())
            //{
            //    if (Input.GetKeyDown(KeyCode.Alpha1))
            //    {
            //        _player.Interacte();
            //    }
            //}
        }

        #endregion


        #region Methods

        private void MoveLeft()
        {
            _player.Movement.Move(-1f);
        }
        private void MoveRight()
        {
            _player.Movement.Move(1f);
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
            if (_player.IsInteractePresent())
            {
                _player.Interacte();
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
