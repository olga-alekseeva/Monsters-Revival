using Abstractions.Basics;
using Abstractions.EnemyParent;
using Abstractions.HealthBar;

namespace Abstractions.SimpleEnemy
{
    internal interface ISimpleEnemyModel : IEnemyParentModel, IHealth, IHealthBarModel
    {
        public ISimpleEnemyModelSettings SimpleEnemyModelSettings { get; }
    }
}
