using Abstractions.Player;

namespace Abstractions.Controllers
{
    internal interface IPlayerDestroyControllerBuilder
    {
        void Build(IPlayerModel playerModel, IPlayerView playerView);
    }
}