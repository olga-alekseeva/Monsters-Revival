using Abstractions.Enemy;

namespace Abstractions.Controllers
{
    internal interface IEnemyDamageControllerBuilder
    {
        void Build(IEnemyModel enemyModel, IEnemyView enemyView);
    }
}