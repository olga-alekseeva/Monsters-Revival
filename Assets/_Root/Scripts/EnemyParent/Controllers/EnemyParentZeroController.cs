using Abstractions.Controllers;
using Abstractions.EnemyParent;

namespace Controllers
{
    internal sealed class EnemyParentZeroController : IEnemyParentZeroController
    {
        private IEnemyParentInfo _enemyParentInfo;

        public EnemyParentZeroController(IEnemyParentInfo enemyParentInfo)
        {
            _enemyParentInfo = enemyParentInfo;
        }

        public void OnEnemyInstantiated(IEnemyParentModel model, IEnemyParentView view)
        {
            _enemyParentInfo.Add(view);
        }

        public void OnEnemyDestroyed(IEnemyParentModel model, IEnemyParentView view)
        {
            _enemyParentInfo.Remove(view);
            CheckZero();
        }

        private void CheckZero()
        {
            if (_enemyParentInfo.GetCount() == 0) _enemyParentInfo.InitiateOnZeroCount();
        }
    }
}