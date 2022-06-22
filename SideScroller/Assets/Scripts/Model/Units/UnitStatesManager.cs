using System;
using UnityEngine;

namespace SideScroller.Model.Unit
{
    class UnitStatesManager
    {
        #region Fields

        public Action StatesChanged;

        private BaseUnit _unit;
        private UnitStatesPositionTypes _unitStates;

        #endregion


        #region Properties

        public UnitStatesPositionTypes UnitStates => _unitStates;

        #endregion

        #region ClassLifeCycle

        public UnitStatesManager(BaseUnit unit)
        {
            _unit = unit;
        }

        ~UnitStatesManager()
        {

        }

        #endregion


        #region Methods


        #endregion

    }
}