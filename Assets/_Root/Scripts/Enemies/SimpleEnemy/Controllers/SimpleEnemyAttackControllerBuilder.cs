using Abstractions.Controllers;
using Abstractions.SimpleEnemy;

namespace Controllers
{
    internal sealed class SimpleEnemyAttackControllerBuilder : ISimpleEnemyAttackControllerBuilder
    {
        public void Build(ISimpleEnemyModel simpleEnemyModel, ISimpleEnemyView simpleEnemyView)
        {
            ISimpleEnemyAttackController controller = new SimpleEnemyAttackController(simpleEnemyModel);
            simpleEnemyView.ActionOnCollisionEnter += controller.OnCollisionEnter2D;
            simpleEnemyView.ActionOnCollisionStay += controller.OnCollisionStay2D;
        }
    }
}
