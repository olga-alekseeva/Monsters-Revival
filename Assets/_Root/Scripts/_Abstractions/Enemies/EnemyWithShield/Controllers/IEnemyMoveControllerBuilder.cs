using Abstractions.Enemy;

namespace Abstractions.Controllers
{
    internal interface IEnemyMoveControllerBuilder
    {
        public void Build(IEnemyModel enemyModel, IEnemyView enemyView);
    }
}