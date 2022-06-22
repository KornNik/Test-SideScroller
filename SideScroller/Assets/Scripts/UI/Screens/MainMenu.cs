using UnityEngine;
using UnityEngine.UI;

namespace SideScroller.UI
{
    class MainMenu : BaseUI
    {
        #region Fields

        [SerializeField] private Button _startGameButton;
        [SerializeField] private Button _quitGameButton;

        #endregion


        #region UnityMethods

        private void OnEnable()
        {
            _startGameButton.onClick.AddListener(OnStartButtonDown);
            _quitGameButton.onClick.AddListener(OnQuitGameButtonDown);
        }

        private void OnDisable()
        {
            _startGameButton.onClick.RemoveListener(OnStartButtonDown);
            _quitGameButton.onClick.RemoveListener(OnQuitGameButtonDown);
        }

        #endregion


        #region Methods

        public override void Show()
        {
            gameObject.SetActive(true);
            ShowUI.Invoke();
        }
        public override void Hide()
        {
            gameObject.SetActive(false);
            HideUI.Invoke();
        }

        private void OnStartButtonDown()
        {
            ScreenInterface.GetInstance().Execute(Types.ScreenTypes.ChooseCharacterMenu);
        }
        private void OnQuitGameButtonDown()
        {
            Application.Quit();
        }

        #endregion
    }
}