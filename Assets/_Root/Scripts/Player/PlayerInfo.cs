using Abstractions.Player;

namespace Player
{
    internal sealed class PlayerInfo : IPlayerInfo
    {
        private IPlayerModel _playerModel;
        private IPlayerView _playerView;
        private bool _isPreset;

        public IPlayerModel PlayerModel => _playerModel;
        public IPlayerView PlayerView => _playerView;
        public bool IsPreset => _isPreset;

        public void Instantiated(IPlayerModel playerModel, IPlayerView playerView)
        {
            _playerModel = playerModel;
            _playerView = playerView;
            _isPreset = true;
        }

        public void Destroyed(IPlayerModel playerModel, IPlayerView playerView)
        {
            _playerModel = null;
            _playerView = null;
            _isPreset = false;
        }
    }
}
