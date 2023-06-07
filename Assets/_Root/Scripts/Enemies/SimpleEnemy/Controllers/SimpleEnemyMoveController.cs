using Abstractions.Controllers;
using Abstractions.Player;
using Abstractions.SimpleEnemy;
using UnityEngine;

namespace Controllers
{
    internal sealed class SimpleEnemyMoveController : ISimpleEnemyMoveController
    {
        private IPlayerInfo _playerInfo;
        private ISimpleEnemyModel _simpleEnemyModel;
        private ISimpleEnemyView _simpleEnemyView;

        private Vector3 _patrolTarget;
        private ITargetPatrolFinder _targetPatrolFinder;
        private Vector3 _lastPosition;
        public SimpleEnemyMoveController(ISimpleEnemyModel simpleEnemyModel,
            ISimpleEnemyView simpleEnemyView, IPlayerInfo playerInfo, ITargetPatrolFinder targetPatrolFinder)
        {
            _playerInfo = playerInfo;
            _simpleEnemyModel = simpleEnemyModel;
            _simpleEnemyView = simpleEnemyView;

            _targetPatrolFinder = targetPatrolFinder;
            _lastPosition = Vector3.zero;
            _patrolTarget = Vector3.zero;
        }

        public void Update(float deltaTime)
        {
            if (!_playerInfo.IsPreset)
            {
                Patroling(deltaTime);
                return;
            }
            if (Vector2.Distance(_simpleEnemyView.Transform.position, _playerInfo.PlayerView.Transform.position)
                > _simpleEnemyModel.SimpleEnemyModelSettings.PatroulingDistance)
            {
                Patroling(deltaTime);
            }
            else if
            (Vector2.Distance(_simpleEnemyView.Transform.position, _playerInfo.PlayerView.Transform.position)
            > _simpleEnemyModel.SimpleEnemyModelSettings.AttackDistance)
            {
                MoveToPlayer(deltaTime);
            }
            else if (Vector2.Distance(_simpleEnemyView.Transform.position, _playerInfo.PlayerView.Transform.position) > _simpleEnemyModel.SimpleEnemyModelSettings.RetreatDistance)
            {
                HoldPositionToAttack(deltaTime);
            }
            else

            {
                Retreat(deltaTime);
            }

        }
        private void MoveToTarget(Vector2 targetPosition)
        {
            _simpleEnemyView.Rigidbody.velocity = Vector2.zero;
            _simpleEnemyView.Rigidbody.MovePosition(targetPosition);
        }
        private void MoveToPlayer(float deltaTime)
        {
            Vector2 targetPosition = Vector2.MoveTowards
                    (_simpleEnemyView.Rigidbody.position,
                    _playerInfo.PlayerView.Transform.position, _simpleEnemyModel.SimpleEnemyModelSettings.Speed * deltaTime);
            MoveToTarget(targetPosition);
        }
        private void Patroling(float deltaTime)
        {
            Vector3 currentPosition = _simpleEnemyView.Transform.position;
            float movedDistance = Vector3.Distance(currentPosition, _lastPosition);
            if (movedDistance <= 0.00001f)
            {
                _patrolTarget = _targetPatrolFinder.GetPatrolTarget(_simpleEnemyView.Rigidbody.position);
            }
            _lastPosition = _simpleEnemyView.Transform.position;
            Vector3 targetPosition = Vector3.MoveTowards
                    (_simpleEnemyView.Rigidbody.position,
                    _patrolTarget, _simpleEnemyModel.SimpleEnemyModelSettings.PatrolSpeed * deltaTime);
            MoveToTarget(targetPosition);
        }
        private void HoldPositionToAttack(float deltaTime)
        {
            Vector3 targetPosition = this._simpleEnemyView.Rigidbody.position;
            MoveToTarget(targetPosition);
        }
        private void Retreat(float deltaTime)
        {
            Vector3 currentPosition = _simpleEnemyView.Transform.position;
            Vector3 targetPosition =
                Vector3.MoveTowards
                (currentPosition, _playerInfo.PlayerView.Transform.position,
                -_simpleEnemyModel.SimpleEnemyModelSettings.RetreatSpeed * Time.deltaTime);
            MoveToTarget(targetPosition);
        }
    }
}
