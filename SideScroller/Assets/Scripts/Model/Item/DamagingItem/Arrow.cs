using UnityEngine;

namespace SideScroller.Model.Item
{
    class Arrow : Projectile
    {
        #region Fields



        #endregion


        #region UnityMethods

        protected override void Awake()
        {
            base.Awake();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            var victim = collision.gameObject.GetComponent<IDamageable>();
            if(victim is IDamageable)
            {
                InflictDamage(victim);
            }

            ReturnToPool();
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