using Abstractions.Controllers;
using Abstractions.Enemy;

namespace Controllers
{
    internal sealed class EnemyDamageApplyControllerBuilder : IEnemyDamageApplyControllerBuilder
    {
        public void Build(IEnemyModel enemyModel, IEnemyView enemyView)
        {
            IEnemyDamageApplyController controller = new EnemyDamageApplyController(enemyModel);
            enemyView.ActionOnCollisionEnter += controller.OnCollisionEnter2D;
            enemyView.ActionOnCollisionStay += controller.OnCollisionStay2D;
        }
    }
}
