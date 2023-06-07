using Abstractions.Arrow;
using Abstractions.Basics;
using Abstractions.Controllers;
using Controllers;

namespace Controller
{
    internal sealed class ArrowMoveControllerBuilder : IArrowMoveControllerBuilder
    {
        private IUpdateableRemoverFactory _updateableRemoverFactory;
        private IUpdateController _updateController;
        public ArrowMoveControllerBuilder(IUpdateController updateController, IUpdateableRemoverFactory updateableRemoverFactory)
        {
            _updateableRemoverFactory = updateableRemoverFactory;
            _updateController = updateController;
        }

        public void Build(IArrowModel arrowModel, IArrowView arrowView)
        {
            IUpdateDeltaTime controller = new ArrowMoveController(arrowModel, arrowView);
            _updateController.Add(controller);
            arrowView.ActionOnDestroy += _updateableRemoverFactory.Create(controller).Remove;
        }
    }
}
