using Abstractions.Controllers;
using Abstractions.SimpleEnemy;

namespace Controllers
{
    internal sealed class SimpleEnemyDamageControllerBuilder : ISimpleEnemyDamageControllerBuilder
    {
        private ISimpleEnemyEventManager _simpleEnemyeEventManager;

        public SimpleEnemyDamageControllerBuilder(ISimpleEnemyEventManager simpleEnemyeEventManager)
        {
            _simpleEnemyeEventManager = simpleEnemyeEventManager;
        }

        public void Build(ISimpleEnemyModel simpleEnemyModel, ISimpleEnemyView simpleEnemyView)
        {
            ISimpleEnemyDamageController controller = new SimpleEnemyDamageController
                (simpleEnemyModel, _simpleEnemyeEventManager, simpleEnemyView);
            simpleEnemyView.ActionOnSetDamage += controller.SetDamage;
        }
    }
}
