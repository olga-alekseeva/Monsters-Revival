using Abstractions.Basics;
using Abstractions.Controllers;
using Abstractions.Player;
using Player;
using UnityEngine;

namespace Controllers
{
    internal sealed class PlayerDamageController : IPlayerDamageController
    {
        private IPlayerModel _playerModel;
        private IPlayerView _playerView;

        public PlayerDamageController(IPlayerModel playerModel, IPlayerView playerView)
        {
            _playerModel = playerModel;
            _playerView = playerView;
        }
        public void SetDamage(IDamage damage)
        {
            _playerModel.Health -= damage.Damage;
            if (_playerModel.Health <= 0)
            {
                _playerModel.Health = 0;
                GameObject.Destroy(_playerView.Transform.gameObject);
            }
        }
    }
}
