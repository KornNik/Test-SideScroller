using UnityEngine;
using SideScroller.Data.Parameter;

namespace SideScroller.Data.Item
{
    [CreateAssetMenu(fileName = "ProjectileParameters",menuName = "Data/Item/ProjectileParameters")]
    class ProjectileParameters : DamagerParameters
    {
        #region Fields

        [SerializeField] private Stat _flyingSpeed;
        [SerializeField] private float _timeToDistract;

        #endregion


        #region Properties

        public Stat FlyingSpeed => _flyingSpeed;
        public float TimeToDistract => _timeToDistract;

        #endregion
    }
}