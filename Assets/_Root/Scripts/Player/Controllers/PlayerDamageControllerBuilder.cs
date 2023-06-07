using Abstractions.Controllers;
using Abstractions.Player;

namespace Controllers
{
    internal sealed class PlayerDamageControllerBuilder : IPlayerDamageControllerBuilder
    {
        public void Build(IPlayerModel playerModel, IPlayerView playerView)
        {
            IPlayerDamageController controller = new PlayerDamageController(playerModel, playerView);
            playerView.ActionOnSetDamage += controller.SetDamage;
        }
    }
}
