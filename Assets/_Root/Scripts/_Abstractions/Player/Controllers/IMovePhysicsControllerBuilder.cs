using Abstractions.Player;

namespace Abstractions.Controllers
{
    internal interface IMovePhysicsControllerBuilder
    {
        void Build(IPlayerModel playerModel, IPlayerView playerView);
    }
}