using UnityEngine;
using SideScroller.Data.Item;

namespace SideScroller.Model.Item
{
    class CommonMeeleWeapon : Weapon
    {
        #region Fields


        #endregion


        #region UnityMethods

        protected override void Awake()
        {
            base.Awake();
        }

        #endregion


        #region Methods

        public override void WeaponAttack(IDamageable damageable)
        {
            base.WeaponAttack(damageable);
            InflictDamage(damageable);
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