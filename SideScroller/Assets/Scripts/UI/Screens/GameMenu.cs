using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using SideScroller.UI.Parts;

namespace SideScroller.UI
{
    class GameMenu : BaseUI
    {
        #region Fields

        [SerializeField] private ControlButton _jumpButton;
        [SerializeField] private ControlButton _attackButton;
        [SerializeField] private ControlButton _leftArrow;
        [SerializeField] private ControlButton _rightArrow;
        [SerializeField] private ControlButton _interactButton;

        [SerializeField] private Button _inventoryButton;

        public static UnityAction Jump;
        public static UnityAction Attack;
        public static UnityAction Interact;
        public static UnityAction LeftArrow;
        public static UnityAction RightArrow;

        #endregion


        #region UnityMethods

        private void OnEnable()
        {
            _jumpButton.onClick.AddListener(OnJumpClick);
            _attackButton.onClick.AddListener(OnAttackClick);
            _interactButton.onClick.AddListener(OnInteracteClick);

            _leftArrow.ButtonPress += OnLeftArrowButtonDown;
            _rightArrow.ButtonPress += OnRightArrowButtonDown;

            _inventoryButton.onClick.AddListener(OnInventoryButtonDown);
        }

        private void OnDisable()
        {
            _jumpButton.onClick.RemoveListener(OnJumpClick);
            _attackButton.onClick.RemoveListener(OnAttackClick);
            _interactButton.onClick.RemoveListener(OnInteracteClick);

            _leftArrow.ButtonPress -= OnLeftArrowButtonDown;
            _rightArrow.ButtonPress -= OnRightArrowButtonDown;

            _inventoryButton.onClick.RemoveListener(OnInventoryButtonDown);
        }

        #endregion


        #region Methods
        private void OnInventoryButtonDown()
        {
            ScreenInterface.GetInstance().Execute(Types.ScreenTypes.InventoryMenu);
        }

        private void OnLeftArrowButtonDown()
        {
            LeftArrow?.Invoke();
        }
        private void OnRightArrowButtonDown()
        {
            RightArrow?.Invoke();
        }
        private void OnInteracteClick()
        {
            Interact?.Invoke();
        }
        private void OnJumpClick()
        {
            Jump?.Invoke();
        }
        private void OnAttackClick()
        {
            Attack?.Invoke();
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