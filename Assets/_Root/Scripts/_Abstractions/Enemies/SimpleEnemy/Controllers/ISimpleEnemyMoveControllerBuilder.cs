using Abstractions.SimpleEnemy;
namespace Abstractions.Controllers
{
    internal interface ISimpleEnemyMoveControllerBuilder
    {
        public void Build(ISimpleEnemyModel enemyModel, ISimpleEnemyView enemyView);
    }
}
