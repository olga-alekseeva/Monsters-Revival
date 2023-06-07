using Abstractions.Controllers;
using Abstractions.Player;

namespace Controllers
{
    internal sealed class PlayerDestroyController : IPlayerDestroyController
    {
        private IPlayerEventOnDestroy _playerEventOnDestroy;
        private IPlayerModel _playerModel;
        private IPlayerView _playerView;

        public PlayerDestroyController(IPlayerEventOnDestroy playerEventOnDestroy, IPlayerModel playerModel, IPlayerView playerView)
        {
            _playerEventOnDestroy = playerEventOnDestroy;
            _playerModel = playerModel;
            _playerView = playerView;
        }
        public void OnDestroy()
        {
            _playerEventOnDestroy.Initiate(_playerModel, _playerView);
        }
    }
}
