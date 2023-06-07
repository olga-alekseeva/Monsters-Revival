using Abstractions.Player;

namespace Abstractions.Controllers
{
    internal interface IPlayerDamageControllerBuilder
    {
        void Build(IPlayerModel playerModel, IPlayerView playerView);
    }
}