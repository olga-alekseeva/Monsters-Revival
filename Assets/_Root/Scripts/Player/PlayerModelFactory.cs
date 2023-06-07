using Abstractions.Player;

namespace Player
{
    internal sealed class PlayerModelFactory : IPlayerModelFactory
    {
        private IPlayerModelSettings _playerModelSettings;

        public PlayerModelFactory(IPlayerModelSettings playerModelSettings)
        {
            _playerModelSettings = playerModelSettings;
        }

        public IPlayerModel Create()
        {
            IPlayerModel playerModel = new PlayerModel(_playerModelSettings);
            return playerModel;
        }
    }
}
