using Abstractions.Basics;
using Abstractions.Controllers;
using Abstractions.Controllers.Fireball;
using Abstractions.Fireball;
using Abstractions.Player;

namespace Controllers.Fireball
{
    internal sealed class FireBallRedirectControllerBuilder 
        : IFireBallRedirectControllerBuilder
    {
        private IUpdateController _updateController;
        private IUpdateableRemoverFactory _updateableRemoverFactory;
        private IPlayerInfo _playerInfo;

        public FireBallRedirectControllerBuilder(
            IUpdateController updateController, 
            IUpdateableRemoverFactory updateableRemoverFactory, 
            IPlayerInfo playerInfo)
        {
            _updateController = updateController;
            _updateableRemoverFactory = updateableRemoverFactory;
            _playerInfo = playerInfo;
        }

        public void Build(IFireballModel model, IFireballView view)
        {
            IUpdate controller = new FireBallRedirectController(view, _playerInfo);
            _updateController.Add(controller);
            view.ActionOnDestroy += _updateableRemoverFactory.Create(controller).Remove;
        }
    }
}
