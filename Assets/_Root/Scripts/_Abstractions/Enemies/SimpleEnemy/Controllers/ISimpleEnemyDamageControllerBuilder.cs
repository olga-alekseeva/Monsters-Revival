using Abstractions.SimpleEnemy;

namespace Abstractions.Controllers
{
    internal interface ISimpleEnemyDamageControllerBuilder
    {
        void Build(ISimpleEnemyModel simpleEnemyModel, ISimpleEnemyView simpleEnemyView);
    }
}
