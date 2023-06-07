namespace Abstractions.Player
{
    internal interface IPlayerViewFactory
    {
        IPlayerView CreateFromScene();
    }
}