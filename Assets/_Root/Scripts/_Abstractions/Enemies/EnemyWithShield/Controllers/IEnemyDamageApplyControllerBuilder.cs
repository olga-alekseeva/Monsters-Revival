using Abstractions.Enemy;

namespace Abstractions.Controllers
{
    internal interface IEnemyDamageApplyControllerBuilder
    {
        void Build(IEnemyModel enemyModel, IEnemyView enemyView);
    }
}