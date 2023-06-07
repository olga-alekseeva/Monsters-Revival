using Abstractions.Player;
using UnityEngine;

namespace Player
{
    internal sealed class PlayerViewFactory : IPlayerViewFactory
    {
        public IPlayerView CreateFromScene()
        {
            IPlayerView playerView = GameObject.FindObjectOfType<PlayerView>();
            return playerView;
        }
    }
}
