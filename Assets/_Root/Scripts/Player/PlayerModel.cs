using Abstractions.Player;
using UnityEngine;

namespace Player
{
    internal sealed class PlayerModel : IPlayerModel
    {
        private IPlayerModelSettings _playerModelSettings;
        private float _healh;

        public IPlayerModelSettings PlayerModelSettings => _playerModelSettings;

        public float Health { get => _healh; set => _healh = value; }

        public float CurrentHealth => _healh;

        public float MaxHealth => _playerModelSettings.Health;

        public Color MinColor => _playerModelSettings.MinColor;

        public Color MaxColor => _playerModelSettings.MaxColor;

        public PlayerModel(IPlayerModelSettings playerModelSettings)
        {
            _playerModelSettings = playerModelSettings;
            _healh = _playerModelSettings.Health;
        }
    }
}
