using Abstractions.Enemy;

namespace Enemy
{
    internal sealed class EnemyModelFactory : IEnemyModelFactory
    {
        private IEnemyModelSettings _enemyModelSettings;

        public EnemyModelFactory(IEnemyModelSettings enemyModelSettings)
        {
            _enemyModelSettings = enemyModelSettings;
        }

        public IEnemyModel Create()
        {
            IEnemyModel enemyModel = new EnemyModel(_enemyModelSettings);
            return enemyModel;
        }
    }
}
