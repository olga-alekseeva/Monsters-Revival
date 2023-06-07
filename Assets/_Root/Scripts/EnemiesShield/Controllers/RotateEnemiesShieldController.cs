using Abstractions.Basics;
using Abstractions.Controllers;
using Abstractions.Fireball;
using Abstractions.Player;
using Player;
using UnityEngine;

namespace Controllers
{
    internal sealed class RotateEnemiesShieldController : IRotateEnemiesShieldController

    {
        private ITransform _shieldTransform;
        private ISpeed _speed;
        private IFireballInfo _fireballInfo;
        private IPlayerInfo _playerInfo;

        public RotateEnemiesShieldController(IPlayerInfo playerInfo, IFireballInfo fireballInfo, ITransform shieldTransform, ISpeed speed)
        {
            _playerInfo = playerInfo;
            _fireballInfo = fireballInfo;
            _shieldTransform = shieldTransform;
            _speed = speed;
        }

        public void Update(float deltaTime)
        {

            if (!_fireballInfo.IsPreset() && !_playerInfo.IsPreset) return;

            Vector3 targetTransform = Vector3.zero;

            if (_playerInfo.IsPreset)
            {
                targetTransform = _playerInfo.PlayerView.Transform.position;
            }
            if (_fireballInfo.IsPreset())
            {
                targetTransform = _fireballInfo.GetNearestFireball(_shieldTransform.Transform).position;
            }
            Vector3 targetPosition = targetTransform;
            Vector3 direction = targetTransform - _shieldTransform.Transform.position;
            float angle = Vector2.Angle(Vector2.up, direction);
            Vector3 axis = Vector3.Cross(Vector3.up, direction);
            Quaternion targetRotation = Quaternion.AngleAxis(angle, axis);
            Quaternion currentRotation = _shieldTransform.Transform.rotation;
            _shieldTransform.Transform.rotation = Quaternion.RotateTowards(currentRotation, targetRotation,
                Time.deltaTime * _speed.Speed);

        }

    }
}
