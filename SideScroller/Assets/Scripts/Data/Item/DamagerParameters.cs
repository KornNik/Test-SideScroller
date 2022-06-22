using UnityEngine;
using SideScroller.Helpers.Types;
using SideScroller.Data.Parameter;

namespace SideScroller.Data.Item
{
    [CreateAssetMenu(fileName ="DamagerParameters",menuName ="Data/Item/DamagerParameters")]
    class DamagerParameters : BaseItemParameters
    {

        #region Fields

        [SerializeField] protected Stat _damage;
        [SerializeField] protected Stat _penetration;
        [SerializeField] protected DamageType _damageType;
        [SerializeField] protected DamageEffectTypes _damageEffectTypes;

        #endregion


        #region Properties

        public Stat Damage => _damage;
        public Stat Penetration => _penetration;
        public DamageType DamageType => _damageType;
        public DamageEffectTypes DamageEffectTypes => _damageEffectTypes;

        #endregion
    }
}
