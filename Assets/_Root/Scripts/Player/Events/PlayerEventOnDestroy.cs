using Abstractions.Player;
using System;

namespace Player.Events
{
    internal sealed class PlayerEventOnDestroy : IPlayerEventOnDestroy
    {
        public event Action<IPlayerModel, IPlayerView> Action = delegate { };

        public void Initiate(IPlayerModel playerModel, IPlayerView playerView)
        {
            Action.Invoke(playerModel, playerView);
        }
    }
}
