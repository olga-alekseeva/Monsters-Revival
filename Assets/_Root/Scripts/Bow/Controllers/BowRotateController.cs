using Abstractions.Basics;
using Abstractions.Controllers;
using Abstractions.Player;
using UnityEngine;

namespace Controllers
{
    internal sealed class BowRotateController : IRotateBowController
    {
        private ITransform _bowTransform;
        private ISpeed _speed;
        private IPlayerInfo _playerInfo;

        public BowRotateController(ITransform bowTransform, ISpeed speed, IPlayerInfo playerInfo)
        {
            _bowTransform = bowTransform;
            _speed = speed;
            _playerInfo = playerInfo;
        }

        public void Update(float deltaTime)
        {
            if (!_playerInfo.IsPreset) return;
            Vector3 targetTransform = Vector3.zero;

            if (_playerInfo.IsPreset)
            {
                targetTransform = _playerInfo.PlayerView.Transform.position;
            }
            Vector3 targetPosition = targetTransform;
            Vector3 direction = targetTransform - _bowTransform.Transform.position;
            float angle = Vector2.Angle(Vector2.up, direction);
            Vector3 axis = Vector3.Cross(Vector3.up, direction);
            Quaternion targetRotation = Quaternion.AngleAxis(angle, axis);
            Quaternion currentRotation = _bowTransform.Transform.rotation;
            _bowTransform.Transform.rotation = Quaternion.RotateTowards(currentRotation, targetRotation,
                Time.deltaTime * _speed.Speed);

        }
    }
}
