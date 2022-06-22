using UnityEngine;
using System.Collections;
using SideScroller.Data.Unit;
using SideScroller.Data.Inventory;
using SideScroller.Model.Inventory;
using SideScroller.Helpers.Managers;
using SideScroller.Model.Unit.Death;
using SideScroller.Model.Unit.Combat;
using SideScroller.Helpers.Extensions;
using SideScroller.Model.Unit.Movement;

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

        [SerializeField] protected BaseUnitParameters _unitParameters;
        [SerializeField] protected InventoryParameters _inventoryParameters;
        [SerializeField] protected BaseCombatParameters _unitCombatParameters;
        [SerializeField] protected BaseMovementParameters _unitMovementParameters;

        protected BaseDeath _death;
        protected BaseCombat _combat;
        protected Equipment _equipment;
        protected BaseMovement _movement;
        protected GroundCheck _groundCheck;
        protected BaseInventory _inventory;
        protected UnitStatesManager _statesManager;
        protected UnitEventManager _unitEventManager;
        protected InventoryEventManager _inventoryEventManager;

        protected bool _isDead;
        protected bool _isFlip;
        protected bool _isVisible;
        protected bool _isColliderActive;
        protected bool _isAlive = true;
        protected bool _isInvinsible = false;

        private Coroutine _invinsibleCoroutine;
        private Collider2D[] _itemsInteractable;

        #endregion


        #region Properties

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
        public BaseInventory Inventory => _inventory;
        public GroundCheck GroundCheck => _groundCheck;
        public BaseUnitParameters Parameters => _unitParameters;
        public UnitStatesManager StatesManager => _statesManager;
        public UnitEventManager UnitEventManager => _unitEventManager;
        public InventoryParameters InventoryParameters => _inventoryParameters;
        public BaseCombatParameters UnitCombatParameters => _unitCombatParameters;
        public BaseMovementParameters UnitMovementParameters => _unitMovementParameters;
        public InventoryEventManager InventoryEventManager => _inventoryEventManager;

        public bool IsAlive => _isAlive;
        public bool IsInvinsible => _isInvinsible;

        #endregion


        #region UnityMehtods

        protected virtual void Awake()
        {
            _unitCollider = GetComponent<Collider2D>();
            _unitSprite = GetComponent<SpriteRenderer>();
            _unitRigidbody = GetComponent<Rigidbody2D>();
            _groundCheckCollider = GetComponentInChildren<Collider2D>();

            _unitEventManager = new UnitEventManager();
            _inventoryEventManager = new InventoryEventManager();

            _statesManager = new UnitStatesManager(this);
            _death = new BaseDeath(this);
            _groundCheck = new GroundCheck(this);
            _equipment = new Equipment(this);
            _inventory = new BaseInventory(this);

            _itemsInteractable = new Collider2D[32];
        }

        protected virtual void Update()
        {
            _groundCheck.LandingCheck();
            _movement.MovementCalculating();
        }

        #endregion


        #region IDamageable

        public virtual void ReceiveDamage(float damage)
        {
            if (!_isInvinsible)
            {
                _unitEventManager.Hurt?.Invoke();
                _unitParameters.TakeDamage(damage);
                _isInvinsible = true;
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

        private IEnumerator InvinsibleTimer()
        {
            yield return new WaitForSeconds(0.3f);
            _invinsibleCoroutine = null;
            _isInvinsible = false;
        }

        public void Interacte()
        {
            var countItems = Physics2D.OverlapCircleNonAlloc(transform.position, 2f, _itemsInteractable, LayersManager.Item);
            for (int i = 0; i < countItems; i++)
            {
                var interactable = _itemsInteractable[i].GetComponent<IInteractable>();
                if (interactable != null)
                {
                    interactable.Interacte(this);
                }
            }
        }
        public bool IsInteractePresent()
        {
            var isFindTarget = Physics2D.OverlapCircle(transform.position, 2f, LayersManager.Item);
            return isFindTarget;
        }

        #endregion

    }
}
