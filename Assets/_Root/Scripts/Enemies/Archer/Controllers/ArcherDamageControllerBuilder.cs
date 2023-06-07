using Abstractions.Controllers;
using Abstractions.Enemy;

namespace Controllers
{
    internal sealed class ArcherDamageControllerBuilder : IArcherDamageControllerBuilder
    {
        private IArcherEventManager _archerEventManager;

        public ArcherDamageControllerBuilder(IArcherEventManager archerEventManager)
        {
            _archerEventManager = archerEventManager;
        }

        public void Build(IArcherModel archerModel, IArcherView archerView)
        {
            IArcherDamageController controller =
                new ArcherDamageController(archerModel, _archerEventManager, archerView);
            archerView.ActionOnSetDamage += controller.SetDamage;
        }
    }
}
