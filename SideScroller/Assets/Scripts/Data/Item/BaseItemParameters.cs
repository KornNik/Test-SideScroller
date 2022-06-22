using UnityEngine;
using SideScroller.Data.Parameter;

namespace SideScroller.Data.Item
{
    abstract class BaseItemParameters : ScriptableObject
    {
        #region Fields

        [SerializeField] protected Stat _mass;
        [SerializeField] private float _value;
        [SerializeField] protected string _name;

        #endregion


        #region Properties

        public Stat Mass => _mass;
        public string Name => _name;
        public float Value => _value;

        #endregion
    }
}
