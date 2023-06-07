using Abstractions.Controllers;
using Abstractions.Player;

namespace Controllers
{
    internal sealed class PlayerDestroyControllerBuilder : IPlayerDestroyControllerBuilder
    {
        private IPlayerEventOnDestroy _playerEventOnDestroy;

        public PlayerDestroyControllerBuilder(IPlayerEventOnDestroy playerEventOnDestroy)
        {
            _playerEventOnDestroy = playerEventOnDestroy;
        }

        public void Build(IPlayerModel playerModel, IPlayerView playerView)
        {
            IPlayerDestroyController controller = new PlayerDestroyController(_playerEventOnDestroy, playerModel, playerView);
            playerView.ActionOnDestroy += controller.OnDestroy;
        }
    }
}
