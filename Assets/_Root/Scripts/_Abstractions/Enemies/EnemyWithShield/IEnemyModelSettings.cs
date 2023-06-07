using Abstractions.Basics;

namespace Abstractions.Enemy
{
    internal interface IEnemyModelSettings : ISpeed, IMinDistance, IHealth, IPatroulingDistance, IAttackDistance, IDamage, IDamageInterval, IMinMaxColor, IPatrolSpeed
    {
        
    }
}
