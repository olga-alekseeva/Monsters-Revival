using Abstractions.SimpleEnemy;

namespace Abstractions.Controllers
{
    internal interface ISimpleEnemyAttackControllerBuilder 
    {
        void Build(ISimpleEnemyModel simpleEnemyModel, ISimpleEnemyView simpleEnemyView);
    }
}
