using UnityEngine;
using System.Collections;
using SideScroller.Helpers;
using SideScroller.Helpers.Managers;
using SideScroller.Data.Unit;
using SideScroller.Data.Inventory;
using SideScroller.Model.Inventory;
using SideScroller.Model.Unit.Death;

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
        protected Health _unitHealth;
        protected Equipment _equipment;
        protected Inventory.Inventory _inventory;
        protected UnitBoolStates _unitBoolStates;
        protected MotionManager _motionManager;
        protected UnitEventManager _unitEventManager;

        protected Vector3 _spawnPosition;

        private Coroutine _invinsibleCoroutine;

        #endregion


        #region Properties


        public Transform AttackArea => _attackArea;
        public SpriteRenderer UnitSprite => _unitSprite;
        public Collider2D UnitCollider => _unitCollider;
        public Rigidbody2D UnitRigidbody => _unitRigidbody;
        public Transform InventoryTransform => _inventoryTransform;
        public Collider2D GroundCheckCollider => _groundCheckCollider;

        public BaseDeath Death => _death;
        public Health UnitHealth => _unitHealth;
        public Equipment Equipment => _equipment;
        public Inventory.Inventory Inventory => _inventory;
        public SurfaceSlider SurfaceSlider => _surfaceSlider;
        public UnitBoolStates UnitBoolStates => _unitBoolStates;
        public MotionManager MotionManager => _motionManager;
        public UnitEventManager UnitEventManager => _unitEventManager;

        public BaseUnitParameters Parameters => _unitParameters;
        public InventoryParameters InventoryParameters => _inventoryParameters;
        public BaseCombatParameters UnitCombatParameters => _unitCombatParameters;
        public BaseMovementParameters UnitMovementParameters => _unitMovementParameters;

        public Vector3 SpawnPosition => _spawnPosition;

        #endregion


        #region UnityMehtods

        protected virtual void Awake()
        {
            GetComponetsFromObject();
            CreateObjectBehaviours();

            _spawnPosition = transform.position;
        }

        protected virtual void OnEnable()
        {
            _unitHealth.HealthParametersChanged += OnHealthChaged;
        }

        protected virtual void OnDisable()
        {
            _unitHealth.HealthParametersChanged -= OnHealthChaged;
        }

        protected virtual void Update()
        {
            _motionManager.MovementUpdate();
        }

        #endregion


        #region IDamageable

        public virtual void ReceiveDamage(float damage)
        {
            if (!_unitBoolStates.IsInvinsible)
            {
                _unitEventManager.Hurt?.Invoke();
                _unitHealth.TakeDamage(damage);
                _unitBoolStates.IsInvinsible = true;
            }
            if (_invinsibleCoroutine == null)
            {
                _invinsibleCoroutine = StartCoroutine(InvinsibleTimer());
            }
            if (_unitHealth.CurrentHealth == 0)
            {
                _unitEventManager.Death?.Invoke();
            }
        }

        #endregion


        #region Methods
        private void GetComponetsFromObject()
        {
            _unitCollider = GetComponent<Collider2D>();
            _unitSprite = GetComponent<SpriteRenderer>();
            _unitRigidbody = GetComponent<Rigidbody2D>();
            _groundCheckCollider = GetComponentInChildren<Collider2D>();
        }
        private void CreateObjectBehaviours()
        {
            _unitBoolStates = new UnitBoolStates();
            _unitEventManager = new UnitEventManager();

            _death = new BaseDeath(this);
            _equipment = new Equipment(this);
            _inventory = new Inventory.Inventory(this);
            _unitHealth = new Health(Parameters);
        }
        private void OnHealthChaged(float health)
        {
            _unitEventManager.HealthChanged?.Invoke(health);
        }

        private IEnumerator InvinsibleTimer()
        {
            yield return new WaitForSeconds(Parameters.InvinsibleDuration);
            _invinsibleCoroutine = null;
            _unitBoolStates.IsInvinsible = false;
        }

        #endregion

    }
}
