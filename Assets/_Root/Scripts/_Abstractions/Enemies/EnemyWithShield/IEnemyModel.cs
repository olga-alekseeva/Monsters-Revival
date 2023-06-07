using Abstractions.Basics;
using Abstractions.EnemyParent;
using Abstractions.HealthBar;

namespace Abstractions.Enemy
{
    internal interface IEnemyModel : IEnemyParentModel, IHealth, IHealthBarModel
    {
        public IEnemyModelSettings EnemyModelSettings { get; }
    }
}
