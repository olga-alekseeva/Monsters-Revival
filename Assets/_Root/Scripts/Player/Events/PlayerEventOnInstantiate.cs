using Abstractions.Player;
using System;

namespace Player.Events
{
    internal sealed class PlayerEventOnInstantiate : IPlayerEventOnInstantiate
    {
        public event Action<IPlayerModel, IPlayerView> Action = delegate { };

        public void Initiate(IPlayerModel playerModel, IPlayerView playerView)
        {
            Action.Invoke(playerModel, playerView);
        }
    }
}
