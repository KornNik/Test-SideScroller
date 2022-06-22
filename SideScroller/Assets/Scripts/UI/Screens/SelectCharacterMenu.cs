using System;
using UnityEngine;
using SideScroller.UI.Parts;
using SideScroller.Data.Cell;
using SideScroller.Helpers.Types;
using System.Collections.Generic;

namespace SideScroller.UI
{
    class SelectCharacterMenu : BaseUI
    {
        #region Fields


        [SerializeField] private Transform _middlePanel;

        public static Action<PlayerCharacterTypes> CharacterSelectType;

        private List<SelectCharacterCell> _characterCells = new List<SelectCharacterCell>();

        #endregion


        #region Properties

        public Transform MiddlePanel => _middlePanel;

        #endregion


        #region Methods

        public void FillCharacterCellsArray(SelectCharacterCell selectCharacterCell)
        {
            _characterCells.Add(selectCharacterCell);
        }
        public void FillCharacterCellsData(ListPlayerCharacters listPlayerCharacters)
        {
            for (int i = 0; i < _characterCells.Count; i++)
            {
                _characterCells[i].SetImage(listPlayerCharacters.PlayerCharactersArray[i].CharacterSprite);
                _characterCells[i].SetText(listPlayerCharacters.PlayerCharactersArray[i].ChracterName);
                _characterCells[i].SetCharacter(listPlayerCharacters.PlayerCharactersArray[i].PlayerCharacterType);
            }
        }
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

        #endregion
    }
}