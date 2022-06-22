using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using SideScroller.Helpers.Types;

namespace SideScroller.UI.Parts
{
    class SelectCharacterCell : MonoBehaviour, IPointerClickHandler
    {
        #region Fields

        [SerializeField] private Image _characterImage;
        [SerializeField] private Text _characterName;

        private PlayerCharacterTypes _playerCharacterType;

        #endregion


        #region Properties

        public PlayerCharacterTypes PlayerCharacterType => _playerCharacterType;

        #endregion


        #region Methods

        public void SetImage(Sprite characterImage)
        {
            _characterImage.sprite = characterImage;
        }
        public void SetText(string characterName)
        {
            _characterName.text = characterName;
        }
        public void SetCharacter(PlayerCharacterTypes playerCharacterType)
        {
            _playerCharacterType = playerCharacterType;
        }

        #endregion


        #region IPointerClickHandler

        public void OnPointerClick(PointerEventData pointerEventData)
        {
            if (PlayerCharacterType != PlayerCharacterTypes.None)
            {
                SelectCharacterMenu.CharacterSelectType?.Invoke(PlayerCharacterType);
                ScreenInterface.GetInstance().Execute(Types.ScreenTypes.InventoryMenu);
            }
            else
            {
                _playerCharacterType = PlayerCharacterTypes.Swordsman;
                SelectCharacterMenu.CharacterSelectType?.Invoke(PlayerCharacterType);
            }
        }

        #endregion

    }
}