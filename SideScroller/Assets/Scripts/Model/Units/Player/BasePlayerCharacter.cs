using System;
using UnityEngine;
using SideScroller.Helpers.Types;
using SideScroller.Model.Unit.Movement;

namespace SideScroller.Model.Unit
{
    abstract class BasePlayerCharacter : BaseUnit
    {
        #region Fields


        #endregion


        #region Properties


        #endregion


        #region UnityMethods

        protected override void Awake()
        {
            base.Awake();
            _movement = new PlayerMovement(_unitMovementParameters, this);
        }

        #endregion

    }
}
