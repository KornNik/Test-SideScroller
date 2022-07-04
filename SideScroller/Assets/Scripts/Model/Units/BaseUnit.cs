using UnityEngine;
using System.Collections;
using SideScroller.Data.Unit;
using SideScroller.Data.Inventory;
using SideScroller.Model.Inventory;
using SideScroller.Model.Unit.Death;
using SideScroller.Model.Unit.Combat;
using SideScroller.Model.Unit.Interact;
using SideScroller.Model.Unit.Movement;
using SideScroller.Helpers;
using SideScroller.Helpers.Managers;
using SideScroller.Helpers.Extensions;

namespace SideScroller.Model.Unit
{
    [RequireComponent(typeof(Collider2D),typeof(Rigidbody2D))]
    abstract class BaseUnit : MonoBehaviour, IDamageable
    {
        #region Fields

        [SerializeField] protected Collider2D _unitCollider;
        [SerializeField] protected Collider2D _groundCheckCollider;
        [SerializeField] protected Rigidbody2D _unitRigidbody;

        [SerializeField] protected Transform _attackArea;
        [SerializeField] protected Transform _inventoryTransform;

        [SerializeField] protected SpriteRenderer _unitSprite;

        [SerializeField] protected SurfaceSlider _surfaceSlider;
        [SerializeField] protected BaseUnitParameters _unitParameters;
        [SerializeField] protected InventoryParameters _inventoryParameters;
        [SerializeField] protected BaseCombatParameters _unitCombatParameters;
        [SerializeField] protected BaseMovementParameters _unitMovementParameters;

        protected BaseDeath _death;
        protected BaseCombat _combat;
        protected Equipment _equipment;
        protected BaseInteract _interact;
        protected BaseMovement _movement;
        protected GroundCheck _groundCheck;
        protected BaseInventory _inventory;
        protected UnitBoolStates _unitBoolStates;
        protected UnitStatesManager _statesManager;
        protected UnitEventManager _unitEventManager;
        protected InventoryEventManager _inventoryEventManager;

        private Coroutine _invinsibleCoroutine;

        #endregion


        #region Properties

        public SurfaceSlider SurfaceSlider => _surfaceSlider;

        public Collider2D UnitCollider => _unitCollider;
        public Rigidbody2D UnitRigidbody => _unitRigidbody;
        public Collider2D GroundCheckCollider => _groundCheckCollider;

        public Transform AttackArea => _attackArea;
        public Transform InventoryTransform => _inventoryTransform;

        public SpriteRenderer UnitSprite => _unitSprite;

        public BaseDeath Death => _death;
        public BaseCombat Combat => _combat;
        public Equipment Equipment => _equipment;
        public BaseMovement Movement => _movement;
        public BaseInteract Interact => _interact;
        public BaseInventory Inventory => _inventory;
        public GroundCheck GroundCheck => _groundCheck;
        public UnitBoolStates UnitBoolStates => _unitBoolStates;
        public BaseUnitParameters Parameters => _unitParameters;
        public UnitStatesManager StatesManager => _statesManager;
        public UnitEventManager UnitEventManager => _unitEventManager;
        public InventoryParameters InventoryParameters => _inventoryParameters;
        public BaseCombatParameters UnitCombatParameters => _unitCombatParameters;
        public BaseMovementParameters UnitMovementParameters => _unitMovementParameters;
        public InventoryEventManager InventoryEventManager => _inventoryEventManager;

        #endregion


        #region UnityMehtods

        protected virtual void Awake()
        {
            _unitCollider = GetComponent<Collider2D>();
            _unitSprite = GetComponent<SpriteRenderer>();
            _unitRigidbody = GetComponent<Rigidbody2D>();
            _groundCheckCollider = GetComponentInChildren<Collider2D>();

            _unitBoolStates = new UnitBoolStates();
            _unitEventManager = new UnitEventManager();
            _inventoryEventManager = new InventoryEventManager();

            _statesManager = new UnitStatesManager(this);
            _death = new BaseDeath(this);
            _groundCheck = new GroundCheck(this);
            _interact = new BaseInteract(this);
            _equipment = new Equipment(this);
            _inventory = new BaseInventory(this);
        }

        protected virtual void OnEnable()
        {
            _unitParameters.HealthParametersChanged += OnHealthChaged;
        }

        protected virtual void OnDisable()
        {
            _unitParameters.HealthParametersChanged -= OnHealthChaged;
        }

        protected virtual void Update()
        {
            _movement.MovementUpdate();
        }

        #endregion


        #region IDamageable

        public virtual void ReceiveDamage(float damage)
        {
            if (!_unitBoolStates.IsInvinsible)
            {
                _unitEventManager.Hurt?.Invoke();
                _unitParameters.TakeDamage(damage);
                _unitBoolStates.IsInvinsible = true;
            }
            if (_invinsibleCoroutine == null)
            {
                _invinsibleCoroutine = StartCoroutine(InvinsibleTimer());
            }
            if (_unitParameters.CurrentHealth == 0)
            {
                _unitEventManager.Death?.Invoke();
            }
        }

        #endregion


        #region Methods

        private void OnHealthChaged(float health)
        {
            _unitEventManager.HealthChanged?.Invoke(health);
        }

        private IEnumerator InvinsibleTimer()
        {
            yield return new WaitForSeconds(0.3f);
            _invinsibleCoroutine = null;
            _unitBoolStates.IsInvinsible = false;
        }

        #endregion

    }
}
