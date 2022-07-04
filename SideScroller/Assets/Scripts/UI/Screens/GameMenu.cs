using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using SideScroller.UI.Parts;
using SideScroller.Model.Unit;
using SideScroller.Helpers.Services;

namespace SideScroller.UI
{
    class GameMenu : BaseUI
    {
        #region Fields

        [SerializeField] private HealthBar _healthBar;
        [SerializeField] private ControlButton _jumpButton;
        [SerializeField] private ControlButton _attackButton;
        [SerializeField] private ControlButton _leftArrow;
        [SerializeField] private ControlButton _rightArrow;
        [SerializeField] private ControlButton _interactButton;

        [SerializeField] private Button _inventoryButton;

        public static UnityAction Jump;
        public static UnityAction Attack;
        public static UnityAction Interact;

        public static UnityAction<bool> LeftArrowBool;
        public static UnityAction<bool> RightArrowBool;

        #endregion


        #region UnityMethods

        protected override void Awake()
        {
            base.Awake();
        }

        private void OnEnable()
        {
            _jumpButton.onClick.AddListener(OnJumpClick);
            _attackButton.onClick.AddListener(OnAttackClick);
            _interactButton.onClick.AddListener(OnInteracteClick);

            _leftArrow.IsButtonPressed += OnLeftArrowButtonDownBool;
            _rightArrow.IsButtonPressed += OnRightArrowButtonDownBool;

            _inventoryButton.onClick.AddListener(OnInventoryButtonDown);

            if(Services.Instance.PlayerService.PlayerCharacter is BaseUnit)
            {
                _healthBar.SetUnit(Services.Instance.PlayerService.PlayerCharacter);
            }

        }

        private void OnDisable()
        {
            _jumpButton.onClick.RemoveListener(OnJumpClick);
            _attackButton.onClick.RemoveListener(OnAttackClick);
            _interactButton.onClick.RemoveListener(OnInteracteClick);

            _leftArrow.IsButtonPressed -= OnLeftArrowButtonDownBool;
            _rightArrow.IsButtonPressed -= OnRightArrowButtonDownBool;

            _inventoryButton.onClick.RemoveListener(OnInventoryButtonDown);

        }

        #endregion


        #region Methods

        private void OnInventoryButtonDown()
        {
            ScreenInterface.GetInstance().Execute(Types.ScreenTypes.InventoryMenu);
        }

        private void OnLeftArrowButtonDownBool(bool isPress)
        {
            LeftArrowBool?.Invoke(isPress);
        }
        private void OnRightArrowButtonDownBool(bool isPress)
        {
            RightArrowBool?.Invoke(isPress);
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