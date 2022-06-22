using UnityEngine;
using SideScroller.Data.Unit.AI;
using SideScroller.Model.Unit.Movement;
using SideScroller.Model.Unit.Combat;
using SideScroller.Helpers.Managers;


namespace SideScroller.Model.Unit.AI
{
    class NPCAI
    {
        #region Fields

        protected BaseNPC _unit;
        protected BaseCombat _combat;
        protected IDamageable _target;
        protected BaseMovement _movement;
        protected AIParameters _AIParameters;

        protected bool _isDead;
        protected bool _isPatrol = true;
        protected bool _isOnPatrolArea = true;

        protected Vector3 _patrolPoint = Vector3.zero;

        private Collider2D[] _targetsToChase; 

        #endregion


        #region ClassLifeCycle

        public NPCAI(BaseNPC unit, BaseMovement movement, BaseCombat combat,AIParameters AIParameters)
        {
            _unit = unit;
            _combat = combat;
            _movement = movement;
            _AIParameters = AIParameters;

            _targetsToChase = new Collider2D[32];
        }

        #endregion


        #region Methods

        public void DoAI()
        {
            if (!IsTargetPresent())
            {
                MovingAction();
            }
            else if (IsTargetPresent())
            {
                AggressiveAction();
            }
        }

        private void AggressiveAction()
        {
            _isOnPatrolArea = false;
            SearchTarget();
        }
        private void MovingAction()
        {
            if (!_isOnPatrolArea)
            {
                BackToPatrolArea();
            }
            else if (_isPatrol)
            {
                Patrol();
            }
        }

        private void MoveToPoint(Vector3 point)
        {
            var pointDirection = point - _unit.transform.position;
            if (pointDirection.x > 0)
            {
                _movement.Move(_unit.UnitMovementParameters.MovingSpeed.BaseValue);
            }
            else { _movement.Move(_unit.UnitMovementParameters.MovingSpeed.BaseValue * -1); }
        }
        protected virtual void Patrol()
        {
            if (_patrolPoint == Vector3.zero)
            {
                _patrolPoint = PatrolPoinGenerator.GeneratePoint(_unit.PatrolPoint, _AIParameters.PatrolDistance);
            }
            MoveToPoint(_patrolPoint);
            if (IsAtStopingDistance(_patrolPoint, 0.8f))
            {
                _patrolPoint = Vector3.zero;
            }
        }
        protected virtual void BackToPatrolArea()
        {
            MoveToPoint(_unit.PatrolPoint);
            if (IsAtStopingDistance(_unit.PatrolPoint, 0.5f))
            {
                _isOnPatrolArea = true;
                _isPatrol = true;
            }
        }
        protected virtual void ChaseTarget(Vector3 targetPosition)
        {
            if (!IsAtStopingDistance(targetPosition, _AIParameters.StopingDistance))
            {
                MoveToPoint(targetPosition);
            }
            else { AttackTarget(_target); }
        }
        protected virtual void AttackTarget(IDamageable damageable)
        {
            _combat.BegginAttack();
        }
        protected virtual void SearchTarget()
        {
            var targetsCount = Physics2D.OverlapCircleNonAlloc(_unit.transform.position, _AIParameters.DistanceView, _targetsToChase, LayersManager.PlayerLayer);
            for (int i = 0; i < targetsCount; i++)
            {
                var victim = _targetsToChase[i].GetComponent<BasePlayerCharacter>();
                if (victim != null)
                {
                    ChaseTarget(victim.transform.position);
                    _target = victim;
                }
            }
        }
        protected virtual bool IsTargetPresent()
        {
            var isFindTarget = Physics2D.OverlapCircle(_unit.transform.position, _AIParameters.DistanceView, LayersManager.PlayerLayer);
            return isFindTarget;
        }
        protected virtual bool IsAtStopingDistance(Vector3 destinationPoint, float stopingDistance)
        {
            if (Vector3.Distance(destinationPoint, _unit.transform.position) <= stopingDistance)
            {
                return true;
            }
            else { return false; }
        }

        #endregion

    }
}
