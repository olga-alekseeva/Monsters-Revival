using Abstractions.Controllers;
using Abstractions.Enemy;
using Abstractions.Player;
using UnityEngine;

namespace Controllers
{
    internal sealed class ArcherMoveController : IArcherMoveController
    {
        private IPlayerInfo _playerInfo;
        private IArcherModel _archerModel;
        private IArcherView _archerView;

        private Vector3 _patrolTarget;
        private ITargetPatrolFinder _targetPatrolFinder;
        private Vector3 _lastPosition;

        public ArcherMoveController
            (IArcherModel archerModel, IArcherView archerView,
            IPlayerInfo playerInfo, ITargetPatrolFinder targetPatrolFinder)
        {
            _archerModel = archerModel;
            _archerView = archerView;
            _playerInfo = playerInfo;

            _patrolTarget = Vector3.zero;
            _targetPatrolFinder = targetPatrolFinder;
            _lastPosition = Vector3.zero;
        }
        public void Update(float deltaTime)
        {
            if (!_playerInfo.IsPreset)
            {
                Patroling(deltaTime);
                return;
            }
            if (Vector2.Distance(_archerView.Transform.position, _playerInfo.PlayerView.Transform.position)
                > _archerModel.ArcherModelSettings.PatroulingDistance)
            {
                Patroling(deltaTime);
            }
            else if
            (Vector2.Distance(_archerView.Transform.position, _playerInfo.PlayerView.Transform.position)
            > _archerModel.ArcherModelSettings.AttackDistance)
            {
                MoveToPlayer(deltaTime);
            }
            else if (Vector2.Distance(_archerView.Transform.position, _playerInfo.PlayerView.Transform.position) > _archerModel.ArcherModelSettings.RetreatDistance)
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
            _archerView.Rigidbody.velocity = Vector2.zero;
            _archerView.Rigidbody.MovePosition(targetPosition);
        }
        private void MoveToPlayer(float deltaTime)
        {
            Vector2 targetPosition = Vector2.MoveTowards
                    (_archerView.Rigidbody.position,
                    _playerInfo.PlayerView.Transform.position, _archerModel.ArcherModelSettings.Speed * deltaTime);
            MoveToTarget(targetPosition);
        }
        private void Patroling(float deltaTime)
        {
            Vector3 currentPosition = _archerView.Transform.position;
            float movedDistance = Vector3.Distance(currentPosition, _lastPosition);
            if (movedDistance <= 0.00001f)
            {
                _patrolTarget = _targetPatrolFinder.GetPatrolTarget(_archerView.Rigidbody.position);
            }
            _lastPosition = _archerView.Transform.position;
            Vector3 targetPosition = Vector3.MoveTowards
                    (_archerView.Rigidbody.position,
                    _patrolTarget, _archerModel.ArcherModelSettings.PatrolSpeed * deltaTime);
            MoveToTarget(targetPosition);
        }
        private void HoldPositionToAttack(float deltaTime)
        {
            Vector3 targetPosition = this._archerView.Rigidbody.position;
            MoveToTarget(targetPosition);
        }
        private void Retreat(float deltaTime)
        {
            Vector3 currentPosition = _archerView.Transform.position;
            Vector3 targetPosition =
                Vector3.MoveTowards
                (currentPosition, _playerInfo.PlayerView.Transform.position,
                -_archerModel.ArcherModelSettings.RetreatSpeed * Time.deltaTime);
            MoveToTarget(targetPosition);
        }

    }
}
