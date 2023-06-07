namespace Abstractions.Player
{
    internal interface IPlayerInfo
    {
        bool IsPreset { get; }
        IPlayerModel PlayerModel { get; }
        IPlayerView PlayerView { get; }

        void Destroyed(IPlayerModel playerModel, IPlayerView playerView);
        void Instantiated(IPlayerModel playerModel, IPlayerView playerView);
    }
}