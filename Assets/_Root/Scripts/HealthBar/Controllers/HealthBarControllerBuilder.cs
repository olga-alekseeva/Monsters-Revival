using Abstractions.Controllers;
using Abstractions.HealthBar;

namespace Controllers
{
    internal sealed class HealthBarControllerBuilder : IHealthBarControllerBuilder
    {
        private IUpdateController _updateController;
        private IUpdateableRemoverFactory _updateableRemoverFactory;

        public HealthBarControllerBuilder(IUpdateController updateController, IUpdateableRemoverFactory updateableRemoverFactory)
        {
            _updateController = updateController;
            _updateableRemoverFactory = updateableRemoverFactory;
        }

        public void Build(IHealthBarModel healthBarModel, IHealthBarView healthBarView)
        {
            IHealthBarController controller = new HealthBarController(healthBarModel, healthBarView);
            _updateController.Add(controller);
            healthBarView.ActionOnDestroy += _updateableRemoverFactory.Create(controller).Remove;
        }
    }
}
