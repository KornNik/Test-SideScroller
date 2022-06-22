using UnityEngine;
using SideScroller.Data.Item;

namespace SideScroller.Model.Item
{
    abstract class Weapon : BaseItem, IDamager
    {
        #region Fields

        [SerializeField] protected WeaponParameters _weaponParameters;

        #endregion


        #region Properties

        public WeaponParameters WeaponParameters => _weaponParameters;

        #endregion


        #region UnityMethods

        protected override void Awake()
        {
            base.Awake();
        }

        #endregion


        #region Methods

        public virtual void WeaponAttack(IDamageable damageable)
        {

        }
        public virtual void WeaponAttack()
        {

        }

        #endregion


        #region IDamager

        public virtual void InflictDamage(IDamageable damageable)
        {
            damageable.ReceiveDamage(_weaponParameters.Damage.BaseValue);
        }

        #endregion
    }
}
