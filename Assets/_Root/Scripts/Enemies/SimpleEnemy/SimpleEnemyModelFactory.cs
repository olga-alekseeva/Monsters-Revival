using Abstractions.SimpleEnemy;
using Enemy;

namespace SimpleEnemy
{
    internal sealed class SimpleEnemyModelFactory : ISimpleEnemyModelFactory
    {
        private ISimpleEnemyModelSettings _simpleEnemyModelSettings;

        public SimpleEnemyModelFactory(ISimpleEnemyModelSettings simpleEnemyModelSettings)
        {
            _simpleEnemyModelSettings = simpleEnemyModelSettings;
        }
        public ISimpleEnemyModel Create()
        {
            ISimpleEnemyModel simpleEnemyModel = new SimpleEnemyModel(_simpleEnemyModelSettings);
            return simpleEnemyModel;

        }
    }
}
