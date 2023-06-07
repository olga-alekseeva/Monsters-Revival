using Abstractions.EnemyParent;

namespace Abstractions.Controllers
{
    internal interface IEnemyParentZeroController
    {
        void OnEnemyDestroyed(IEnemyParentModel model, IEnemyParentView view);
        void OnEnemyInstantiated(IEnemyParentModel model, IEnemyParentView view);
    }
}