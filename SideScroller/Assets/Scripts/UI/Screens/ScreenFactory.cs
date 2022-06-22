using UnityEngine;
using SideScroller.Helpers;
using SideScroller.Helpers.AssetsPath;
using SideScroller.UI.Types;
using SideScroller.UI.Parts;
using SideScroller.Data.Cell;
using SideScroller.Data.Inventory;

namespace SideScroller.UI
{
    sealed class ScreenFactory
    {
        #region Fields

        private Canvas _canvas;
        private GameMenu _gameMenu;
        private MainMenu _mainMenu;
        private CharacterMenu _inventoryMenu;
        private SelectCharacterMenu _chooseCharacterMenu;

        private ListPlayerCharacters _listPlayerCharacters;
        private InventoryParameters _inventoryParameters;

        #endregion


        #region ClassLifeCycles

        public ScreenFactory()
        {
            var resources = CustomResources.Load<Canvas>(ScreenAssetPath.Screens[ScreenTypes.Canvas].Screen);
            _canvas = Object.Instantiate(resources, Vector3.one, Quaternion.identity);

            var playerResources = CustomResources.Load<ListPlayerCharacters>(DatasAssetPath.DatasPath[Helpers.Types.DataTypes.ListPlayerCharacters]);
            _listPlayerCharacters = playerResources;

            var inventroyParameters = CustomResources.Load<InventoryParameters>(DatasAssetPath.DatasPath[Helpers.Types.DataTypes.InventoryData]);
            _inventoryParameters = inventroyParameters;
        }

        #endregion


        #region Methods

        public GameMenu GetGameMenu()
        {
            if (_gameMenu == null)
            {
                var resources = CustomResources.Load<GameMenu>(ScreenAssetPath.Screens[ScreenTypes.GameMenu].Screen);
                _gameMenu = Object.Instantiate(resources, _canvas.transform.position, Quaternion.identity, _canvas.transform);
            }
            return _gameMenu;
        }

        public MainMenu GetMainMenu()
        {
            if (_mainMenu == null)
            {
                var resources = CustomResources.Load<MainMenu>(ScreenAssetPath.Screens[ScreenTypes.MainMenu].Screen);
                _mainMenu = Object.Instantiate(resources, _canvas.transform.position, Quaternion.identity, _canvas.transform);
            }
            return _mainMenu;
        }

        public CharacterMenu GetInventoryMenu()
        {
            if (_inventoryMenu == null)
            {
                var resources = CustomResources.Load<CharacterMenu>(ScreenAssetPath.Screens[ScreenTypes.InventoryMenu].Screen);
                _inventoryMenu = Object.Instantiate(resources, _canvas.transform.position, Quaternion.identity, _canvas.transform);

                var elements = CustomResources.Load<ItemCell>(ScreenAssetPath.Screens
                    [ScreenTypes.InventoryMenu].Elements[ScreenElementTypes.ItemCell]);

                ItemCell[] itemsList = new ItemCell[_inventoryParameters.InventorySize];
                for (int i = 0; i < _inventoryParameters.InventorySize; i++)
                {
                    var cell = Object.Instantiate(elements, _inventoryMenu.InventoryUI.ItemPlace.content.position, Quaternion.identity,
                        _inventoryMenu.InventoryUI.ItemPlace.content.transform);
                    itemsList[i] = cell;
                }
                _inventoryMenu.InventoryUI.FillItemsArray(itemsList);
            }
            return _inventoryMenu;
        }

        public SelectCharacterMenu GetChooseCharacterMenu()
        {
            if(_chooseCharacterMenu == null)
            {
                var resources = CustomResources.Load<SelectCharacterMenu>(ScreenAssetPath.Screens[ScreenTypes.ChooseCharacterMenu].Screen);
                _chooseCharacterMenu = Object.Instantiate(resources, _canvas.transform.position, Quaternion.identity, _canvas.transform);

                var elements = CustomResources.Load<SelectCharacterCell>(ScreenAssetPath.Screens
                    [ScreenTypes.ChooseCharacterMenu].Elements[ScreenElementTypes.SelectCharacterCell]);

                for (int i = 0; i < _listPlayerCharacters.PlayerCharactersArray.Length; i++)
                {
                    var cell = Object.Instantiate(elements, _chooseCharacterMenu.MiddlePanel.transform.position, Quaternion.identity, _chooseCharacterMenu.MiddlePanel.transform);
                    _chooseCharacterMenu.FillCharacterCellsArray(cell);
                }
                _chooseCharacterMenu.FillCharacterCellsData(_listPlayerCharacters);
            }
            return _chooseCharacterMenu;
        }

        #endregion

    }
}