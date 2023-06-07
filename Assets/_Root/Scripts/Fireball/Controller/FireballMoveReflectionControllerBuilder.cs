using Abstractions.Basics;
using Abstractions.Controllers;
using Abstractions.Controllers.Fireball;
using Abstractions.Fireball;

namespace Controllers
{
    internal sealed class FireballMoveReflectionControllerBuilder : IFireballMoveReflectionControllerBuilder
    {
        private IUpdateController _updateController;
        private IUpdateableRemoverFactory _updateableRemoverFactory;

        public FireballMoveReflectionControllerBuilder(IUpdateController updateController, IUpdateableRemoverFactory updateableRemoverFactory)
        {
            _updateController = updateController;
            _updateableRemoverFactory = updateableRemoverFactory;
        }

        public void Build(IFireballModel model, IFireballView view)
        {
            IUpdateDeltaTime controller = new FireballMoveReflectionController(model, view);
            _updateController.Add(controller);
            view.ActionOnDestroy += _updateableRemoverFactory.Create(controller).Remove;
        }
    }
}
