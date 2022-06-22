using System;
using UnityEngine;
using System.Collections.Generic;

namespace SideScroller.Data.Parameter
{
    [CreateAssetMenu(fileName = "Stat", menuName = "Data/Unit/Stat")]
    class Stat : ScriptableObject
    {
        #region Fields

        [SerializeField] private float _baseValue;

        public event Action<float> OnStatChanged;

        private List<float> _modifiers = new List<float>();

        #endregion


        #region Properties

        public float BaseValue
        {
            get
            {
                return _baseValue;
            }
            set
            {
                _baseValue = value;
                OnStatChanged?.Invoke(GetValue());
            }
        }

        #endregion


        #region Methods

        public float GetValue()
        {
            var finalValue = _baseValue;
            _modifiers.ForEach(x => finalValue += x);
            return finalValue;
        }
        public void AddModifier(float modifier)
        {
            if (modifier != 0)
            {
                _modifiers.Add(modifier);
                OnStatChanged?.Invoke(GetValue());
            }
        }
        public void RemoveModifier(float modifier)
        {
            if (modifier != 0)
            {
                _modifiers.Remove(modifier);
                OnStatChanged?.Invoke(GetValue());
            }
        }

        #endregion
    }
}
