using Abstractions.Basics;
using Abstractions.EnemyParent;
using Abstractions.HealthBar;

namespace Abstractions.Enemy
{
    internal interface IArcherModel : IEnemyParentModel, IHealth, IHealthBarModel
    {
        public IArcherModelSettings ArcherModelSettings { get; }
    }
}
