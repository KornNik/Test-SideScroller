using UnityEngine;
using SideScroller.Helpers.Pool;
using SideScroller.Helpers.Types;

namespace SideScroller.Model.Item
{
    class CommonRangedWeapon : Weapon
    {
        #region Fields

        [SerializeField] protected Transform _poolTransform;
        protected PoolObjects<ProjectileTypes> _projectilePool;
        protected ProjectileTypes _projectileType = ProjectileTypes.Arrow;

        #endregion


        #region UnityMethods

        protected override void Awake()
        {
            base.Awake();
            _projectilePool = new ProjectilePool(5, _poolTransform);
        }

        #endregion


        #region Methods

        public override void WeaponAttack()
        {
            base.WeaponAttack();
            var projectile = _projectilePool.GetObject(_projectileType);
            projectile.ActiveObject();
        }

        #endregion


        #region IDamager

        public override void InflictDamage(IDamageable damageable)
        {
            base.InflictDamage(damageable);
        }

        #endregion
    }
}

