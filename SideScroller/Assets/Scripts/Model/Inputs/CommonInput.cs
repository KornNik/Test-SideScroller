using SideScroller.Model.Unit;
using SideScroller.UI;

namespace SideScroller.Model.Inputs
{
    class CommonInput : BaseInputs
    {
        #region Fields

        private BasePlayerCharacter _player;

        #endregion


        #region ClasLifeCycle

        public CommonInput(BasePlayerCharacter player):base()
        {
            _player = player;

            GameMenu.Jump += Jump;
            GameMenu.Attack += Attack;
            GameMenu.Interact += Interacte;

            GameMenu.LeftArrowBool += MoveLeftBool;
            GameMenu.RightArrowBool += MoveRightBool;
        }

        ~CommonInput()
        {
            GameMenu.Jump -= Jump;
            GameMenu.Attack -= Attack;
            GameMenu.Interact -= Interacte;

            GameMenu.LeftArrowBool -= MoveLeftBool;
            GameMenu.RightArrowBool -= MoveRightBool;
        }
        #endregion


        #region Methods

        public override void InputsEntry()
        {

        }

        private void MoveLeftBool(bool isPress)
        {
            if (isPress)
            {
                _player.MotionManager.Movement.Move(-1f,0f);
            }
            else if (!isPress)
            {
                _player.MotionManager.Movement.Stop();
            }
        }
        private void MoveRightBool(bool isPress)
        {
            if (isPress)
            {
                _player.MotionManager.Movement.Move(1f,0f);
            }
            else if (!isPress)
            {
                _player.MotionManager.Movement.Stop();
            }
        }
        private void Attack()
        {
            _player.MotionManager.Combat.BegginAttack();
        }

        private void Jump()
        {
            _player.MotionManager.Movement.Jump();
        }
        private void Interacte()
        {
            if (_player.MotionManager.Interact.IsInteractPresent())
            {
                _player.MotionManager.Interact.InteractWithObjects();
            }
        }

        #endregion
    }
}
