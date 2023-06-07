using Abstractions.Controllers;
using Abstractions.Enemy;
using Abstractions.Player;
using UnityEngine;

namespace Controllers
{
    internal sealed class EnemyMoveController : IEnemyMoveController
    {
        private IEnemyModel _enemyModel;
        private IEnemyView _enemyView;
        private IPlayerInfo _playerInfo;

        private bool _isPatrol;
        private Vector3 _patrolTarget;
        private ITargetPatrolFinder _targetPatrolFinder;
        private Vector3 _lastPosition;



        public EnemyMoveController
            (IEnemyModel enemyModel, IEnemyView enemyView,
            IPlayerInfo playerInfo, ITargetPatrolFinder targetPatrolFinder)
        {
            _enemyModel = enemyModel;
            _enemyView = enemyView;
            _playerInfo = playerInfo;

            _isPatrol = false;
            _patrolTarget = Vector3.zero;
            _targetPatrolFinder = targetPatrolFinder;
            _lastPosition = Vector3.zero;
        }

        private void MoveToTarget(Vector2 targetPosition)
        {
            _enemyView.Rigidbody.velocity = Vector2.zero;
            _enemyView.Rigidbody.MovePosition(targetPosition);
        }

        private void MoveToPlayer(float deltaTime)
        {
            Vector2 targetPosition = Vector2.MoveTowards
                    (_enemyView.Rigidbody.position,
                    _playerInfo.PlayerView.Transform.position, _enemyModel.EnemyModelSettings.Speed * deltaTime);
            MoveToTarget(targetPosition);
        }

        private void Patroling(float deltaTime)
        {
            if (!_isPatrol) return;
            Vector2 targetPosition = Vector2.MoveTowards
                    (_enemyView.Rigidbody.position,
                    _patrolTarget, _enemyModel.EnemyModelSettings.PatrolSpeed * deltaTime);
            MoveToTarget(targetPosition);
        }

        public void Update(float deltaTime)
        {
            float lastDistance = Vector3.Distance(_enemyView.Transform.position, _lastPosition);
            if (lastDistance <= 0.0001f)
            {
                _isPatrol = true;
                _patrolTarget = _targetPatrolFinder.GetPatrolTarget(_enemyView.Rigidbody.position);
            }
            _lastPosition = _enemyView.Transform.position;

            if (!_playerInfo.IsPreset)
            {
                Patroling(deltaTime);
            }
            else if (Vector2.Distance(_enemyView.Transform.position, _playerInfo.PlayerView.Transform.position) < _enemyModel.EnemyModelSettings.PatroulingDistance)
            {
                MoveToPlayer(deltaTime);
            }
            else
            {
                Patroling(deltaTime);
            }

        }
    }
}
