using UnityEngine;
using SideScroller.Helpers;
using SideScroller.Data.Item;

namespace SideScroller.Model.Item
{
    abstract class Projectile : BaseItem, IPoolable, IDamager
    {

        #region Fields

        [SerializeField] protected ProjectileParameters _projectileParameters;
        [SerializeField] protected Rigidbody2D _projectileRigidbody;

        protected Transform _poolTransform;

        #endregion


        #region Properties

        public Transform PoolTransform { get { return _poolTransform; } set { _poolTransform = value; } }

        public GameObject PoolableObject { get { return gameObject; } set { PoolableObject.SetActive(value); } }

        #endregion


        #region UnityMethods

        protected override void Awake()
        {
            base.Awake();
            _projectileRigidbody = GetComponent<Rigidbody2D>();
            _isReadyToInteract = false;
        }

        #endregion


        #region Methods

        private void ProjectileFly()
        {
            var flyingSpeed =  _projectileParameters.FlyingSpeed.BaseValue * Time.fixedDeltaTime;
            _projectileRigidbody.AddForce(PoolTransform.right * flyingSpeed, ForceMode2D.Impulse);
        }

        #endregion


        #region IDamager

        public virtual void InflictDamage(IDamageable damageable)
        {
            damageable.ReceiveDamage(_projectileParameters.Damage.BaseValue);
        }

        #endregion


        #region IPoolable

        public void ReturnToPool()
        {
            transform.SetParent(PoolTransform);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            _projectileRigidbody.velocity = Vector3.zero;
            gameObject.SetActive(false);
            CancelInvoke(nameof(ReturnToPool));

            if (!PoolTransform)
            {
                Destroy(gameObject);
            }
        }

        public void ActiveObject()
        {
            gameObject.SetActive(true);
            Invoke(nameof(ReturnToPool), _projectileParameters.TimeToDistract);
            transform.SetParent(null);
            ProjectileFly();
        }

        #endregion
    }
}
