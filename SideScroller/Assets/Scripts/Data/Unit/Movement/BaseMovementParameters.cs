using System;
using UnityEngine;
using SideScroller.Data.Parameter;

namespace SideScroller.Data.Unit
{
    [CreateAssetMenu(fileName = "BaseMovementParameters", menuName = "Data/Unit/BaseMovementParameters")]
    class BaseMovementParameters : ScriptableObject
    {
        #region Fields

        [SerializeField] private Stat _movingSpeed;
        [SerializeField] private Stat _jumpHeight;
        [SerializeField] private Stat _runningSpeed;

        [SerializeField] protected float _inAirSpeedMovementMultiplier;
        [SerializeField] protected float _jumpingDirectionMovementMultiplier;
        #endregion


        #region Properties

        public Stat MovingSpeed => _movingSpeed;
        public Stat JumpHeght => _jumpHeight;
        public Stat RunningSpeed => _runningSpeed;

        public float InAirSpeedMovementMultiplier => _inAirSpeedMovementMultiplier;
        public float JumpingDirectionMovementMultiplier => _jumpingDirectionMovementMultiplier;


        #endregion
    }
}
