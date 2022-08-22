using System;
using UnityEngine;
using SideScroller.Data.Parameter;

namespace SideScroller.Data.Unit
{
    abstract class BaseUnitParameters : ScriptableObject
    {
        #region Fields

        [SerializeField] protected Stat _maxHealth;
        [SerializeField] protected Stat _armor;
        [SerializeField] protected BaseMovementParameters _baseMovement;

        [SerializeField] protected float _interactDistance;
        [SerializeField] protected float _invinsibleDuration;

        #endregion


        #region Properties

        public Stat MaxHealth => _maxHealth;
        public Stat Armor => _armor;
        public BaseMovementParameters BaseMovement => _baseMovement;

        public float InteractDistance => _interactDistance;
        public float InvinsibleDuration => _invinsibleDuration;


        #endregion

    }
}
