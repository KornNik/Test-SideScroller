using System;
using SideScroller.UI.Types;


namespace SideScroller.UI
{
    sealed class ScreenInterface : IDisposable
    {
        #region Fields

        private BaseUI _currentWindow;
        private readonly ScreenFactory _screenFactory;
        private static ScreenInterface _instance;

        #endregion


        #region ClassLifeCycles

        private ScreenInterface()
        {
            _screenFactory = new ScreenFactory();
        }

        #endregion


        #region Properties

        public BaseUI CurrentWindow => _currentWindow;

        #endregion


        #region Methods

        public static ScreenInterface GetInstance()
        {
            return _instance ?? (_instance = new ScreenInterface());
        }

        public void Execute(ScreenTypes screenType)
        {
            if (CurrentWindow != null)
            {
                CurrentWindow.Hide();
            }

            switch (screenType)
            {
                case ScreenTypes.GameMenu:
                    _currentWindow = _screenFactory.GetGameMenu();
                    break;
                case ScreenTypes.MainMenu:
                    _currentWindow = _screenFactory.GetMainMenu();
                    break;
                case ScreenTypes.ChooseCharacterMenu:
                    _currentWindow = _screenFactory.GetChooseCharacterMenu();
                    break;
                case ScreenTypes.InventoryMenu:
                    _currentWindow = _screenFactory.GetInventoryMenu();
                    break;
                default:
                    break;
            }

            CurrentWindow.Show();
        }

        public void AddObserver(ScreenTypes screenType, IListenerScreen listenerScreen)
        {
            switch (screenType)
            {
                case ScreenTypes.GameMenu:
                    _screenFactory.GetGameMenu().ShowUI += listenerScreen.ShowScreen;
                    _screenFactory.GetGameMenu().HideUI += listenerScreen.HideScreen;
                    _screenFactory.GetGameMenu().Hide();
                    break;
                case ScreenTypes.MainMenu:
                    _screenFactory.GetMainMenu().ShowUI += listenerScreen.ShowScreen;
                    _screenFactory.GetMainMenu().HideUI += listenerScreen.HideScreen;
                    _screenFactory.GetMainMenu().Hide();
                    break;
                case ScreenTypes.ChooseCharacterMenu:
                    _screenFactory.GetChooseCharacterMenu().ShowUI += listenerScreen.ShowScreen;
                    _screenFactory.GetChooseCharacterMenu().HideUI += listenerScreen.HideScreen;
                    _screenFactory.GetChooseCharacterMenu().Hide();
                    break;
                case ScreenTypes.InventoryMenu:
                    _screenFactory.GetInventoryMenu().ShowUI += listenerScreen.ShowScreen;
                    _screenFactory.GetInventoryMenu().HideUI += listenerScreen.HideScreen;
                    _screenFactory.GetInventoryMenu().Hide();
                    break;
                default:
                    break;
            }
        }

        public void RemoveObserver(ScreenTypes screenType, IListenerScreen listenerScreen)
        {
            switch (screenType)
            {
                case ScreenTypes.GameMenu:
                    _screenFactory.GetGameMenu().ShowUI -= listenerScreen.ShowScreen;
                    _screenFactory.GetGameMenu().HideUI -= listenerScreen.HideScreen;
                    _screenFactory.GetGameMenu().Hide();
                    break;
                case ScreenTypes.MainMenu:
                    _screenFactory.GetMainMenu().ShowUI -= listenerScreen.ShowScreen;
                    _screenFactory.GetMainMenu().HideUI -= listenerScreen.HideScreen;
                    _screenFactory.GetMainMenu().Hide();
                    break;
                case ScreenTypes.ChooseCharacterMenu:
                    _screenFactory.GetChooseCharacterMenu().ShowUI -= listenerScreen.ShowScreen;
                    _screenFactory.GetChooseCharacterMenu().HideUI -= listenerScreen.HideScreen;
                    _screenFactory.GetChooseCharacterMenu().Hide();
                    break;
                case ScreenTypes.InventoryMenu:
                    _screenFactory.GetInventoryMenu().ShowUI -= listenerScreen.ShowScreen;
                    _screenFactory.GetInventoryMenu().HideUI -= listenerScreen.HideScreen;
                    _screenFactory.GetInventoryMenu().Hide();
                    break;
                default:
                    break;
            }
        }

        #endregion


        #region IDisposable

        public void Dispose()
        {
            _instance = null;
        }

        #endregion
    }
}
