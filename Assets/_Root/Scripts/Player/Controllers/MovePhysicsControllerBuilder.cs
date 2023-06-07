using Abstractions.Basics;
using Abstractions.Controllers;
using Abstractions.InputSystem;
using Abstractions.Player;

namespace Controllers
{
    internal sealed class MovePhysicsControllerBuilder : IMovePhysicsControllerBuilder
    {
        private IUpdateController _updateController;
        private IInputModel _inputModel;
        private IUpdateableRemoverFactory _updateableRemoverFactory;

        public MovePhysicsControllerBuilder(IUpdateController updateController, IUpdateableRemoverFactory updateableRemoverFactory, IInputModel inputModel)
        {
            _updateController = updateController;
            _inputModel = inputModel;
            _updateableRemoverFactory = updateableRemoverFactory;
        }

        public void Build(IPlayerModel playerModel, IPlayerView playerView)
        {
            IUpdateDeltaTime movePhysicsController = new MovePhysicsController(playerView, _inputModel, playerModel.PlayerModelSettings);
            _updateController.Add(movePhysicsController);
            playerView.ActionOnDestroy += _updateableRemoverFactory.Create(movePhysicsController).Remove;
        }
    }
}
