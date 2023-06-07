using Abstractions.Basics;
using Abstractions.Controllers;
using Abstractions.Controllers.Fireball;
using Abstractions.Fireball;
using Abstractions.Player;
using UnityEngine;

namespace Controllers.Fireball
{

    internal sealed class FireBallRedirectController : IFireBallRedirectController
    {
        private const float MAX_DISTANCE_TO_CALCULATE = 0.75f;
        private const float MAX_DISTANCE_TO_REDIRECT = 0.5f;
        private IFireballView _fireballView;
        private IPlayerInfo _playerInfo;

        public FireBallRedirectController(IFireballView fireballView, IPlayerInfo playerInfo)
        {
            _fireballView = fireballView;
            _playerInfo = playerInfo;
        }

        private float DistanceToCut(float x0, float y0, float x1, float y1, float x2, float y2)
        {
            float upValue = Mathf.Abs((y2 - y1) * x0 - (x2 - x1) * y0 + x2 * y1 - y2 * x1);
            float dy = y2 - y1;
            float dx = x2 - x1;
            float downValue = Mathf.Sqrt(dy * dy + dx * dx);
            return upValue / downValue;
        }

        public void Update()
        {
            if (!_playerInfo.IsPreset) return;

            float distance = Vector2.Distance(_playerInfo.PlayerView.Transform.position, _fireballView.Transform.position);
            if (distance > MAX_DISTANCE_TO_CALCULATE) return;

            Vector2 point0 = _fireballView.Transform.position;
            Vector2 point1 = _playerInfo.PlayerView.Transform.position;
            Vector2 point2 = _playerInfo.PlayerView.SpawnTransform.position;

            float distanceToCut = DistanceToCut(point0.x, point0.y, point1.x, point1.y, point2.x, point2.y);
            if (distanceToCut <= MAX_DISTANCE_TO_REDIRECT)
            {
                Rigidbody2D rigidbody2D = _fireballView.Rigidbody;
                rigidbody2D.velocity = (point2 - point1).normalized;
            }
        }
    }
}
