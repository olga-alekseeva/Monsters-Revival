using Abstractions.Controllers;
using Abstractions.Enemy;

namespace Controllers
{

    internal sealed class EnemyDamageControllerBuilder 
        : IEnemyDamageControllerBuilder
    {
        private IEnemyEventManager _enemyEventManager;

        public EnemyDamageControllerBuilder(IEnemyEventManager enemyEventManager)
        {
            _enemyEventManager = enemyEventManager;
        }

        public void Build(IEnemyModel enemyModel, IEnemyView enemyView)
        {
            IEnemyDamageController controller = 
                new EnemyDamageController(
                    _enemyEventManager, enemyModel, enemyView);

            enemyView.ActionOnSetDamage += controller.SetDamage;
        }
    }
}