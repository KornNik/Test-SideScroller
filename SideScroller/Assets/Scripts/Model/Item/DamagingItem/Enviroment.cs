using UnityEngine;
using SideScroller.Data.Item;

namespace SideScroller.Model.Item
{
    class Enviroment : MonoBehaviour, IDamager
    {
        #region Fields

        [SerializeField] protected Collider2D _collider;
        [SerializeField] protected SpriteRenderer _spriteRenderer;
        [SerializeField] protected DamagerParameters _enviromentDamagerParameters;

        #endregion


        #region UnityMethods

        protected virtual void Awake()
        {

        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            var damageable = collision.GetComponent<IDamageable>();
            var rigidbody = collision.GetComponent<Rigidbody2D>();
            if (damageable != null)
            {
                InflictDamage(damageable);
                if (rigidbody != null)
                {
                    var direction = collision.transform.position - transform.position;
                    rigidbody.AddForce((direction + rigidbody.transform.up) * 1.2f, ForceMode2D.Impulse);
                }
            }
        }

        #endregion


        #region IDamager

        public void InflictDamage(IDamageable damageable)
        {
            damageable.ReceiveDamage(_enviromentDamagerParameters.Damage.BaseValue);
        }

        #endregion
    }
}
