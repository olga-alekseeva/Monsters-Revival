using Abstractions.Controllers;
using Abstractions.Player;

namespace Controllers
{
    internal sealed class PlayerExitPortalControllerBuilder : IPlayerExitPortalControllerBuilder
    {
        public void Build(IPlayerModel playerModel, IPlayerView playerView)
        {
            IPlayerExitPortalController playerExitPortalController = new PlayerExitPortalController();
            playerView.ActionOnTriggerEnter += playerExitPortalController.OnTriggerEnter2D;
        }
    }
}
