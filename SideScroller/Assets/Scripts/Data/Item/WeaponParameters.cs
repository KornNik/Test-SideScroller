using UnityEngine;
using SideScroller.Helpers.Types;
using SideScroller.Data.Parameter;

namespace SideScroller.Data.Item
{
    [CreateAssetMenu(fileName ="WeaponParameters",menuName ="Data/Item/WeaponParameters")]
    class WeaponParameters : DamagerParameters
    {
        #region Fields

        [SerializeField] protected Stat _speed;
        [SerializeField] protected Sprite _icon;
        [SerializeField] protected WeaponType _weaponType;

        #endregion


        #region Properties

        public Stat Speed => _speed;
        public WeaponType WeaponType => _weaponType;

        #endregion
    }
}
