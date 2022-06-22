using System;
using UnityEngine;
using UnityEngine.UI;
using SideScroller.UI.Parts;
using SideScroller.Model.Item;

namespace SideScroller.UI
{
    class CharacterMenu : BaseUI
    {

        #region Fields

        public static Action<BaseItem> ItemShiftedInUIInventory;
        public static Action<BaseItem> ItemShiftedInUIEquipment;

        [SerializeField] private CharacterEquipmentUI _equipmentUI;
        [SerializeField] private CharacterInventoryUI _inventoryUI;
        [SerializeField] private Button _backToGameButton;

        #endregion


        #region Properties

        public CharacterEquipmentUI EquipmentUI => _equipmentUI;
        public CharacterInventoryUI InventoryUI => _inventoryUI;

        #endregion


        #region UnityMethods

        private void OnEnable()
        {
            _backToGameButton.onClick.AddListener(OnBackToGameButtonClick);
        }

        private void OnDisable()
        {
            _backToGameButton.onClick.RemoveListener(OnBackToGameButtonClick);
        }

        #endregion


        #region Methods

        private void OnBackToGameButtonClick()
        {
            ScreenInterface.GetInstance().Execute(Types.ScreenTypes.GameMenu);
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
