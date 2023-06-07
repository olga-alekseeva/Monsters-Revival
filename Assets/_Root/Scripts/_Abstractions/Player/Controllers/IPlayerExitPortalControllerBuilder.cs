using Abstractions.Player;

namespace Abstractions.Controllers
{
    internal interface IPlayerExitPortalControllerBuilder
    {
        void Build(IPlayerModel playerModel, IPlayerView playerView);
    }
}