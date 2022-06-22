using UnityEngine;
using SideScroller.Data.Parameter;

namespace SideScroller.Data.Unit
{
    [CreateAssetMenu(fileName = "CombatParameters", menuName = "Data/Unit/CombatParameters")]
    class BaseCombatParameters : ScriptableObject
    {
        #region Fields

        [SerializeField] protected Stat _speed;
        [SerializeField] protected Stat _rechargeTime;

        #endregion

        #region Properties

        public Stat Speed => _speed;
        public Stat RechargeTime => _rechargeTime;

        #endregion

    }
}