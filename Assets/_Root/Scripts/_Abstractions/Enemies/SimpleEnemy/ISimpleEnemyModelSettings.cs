using Abstractions.Basics;
using Abstractions.Enemy;

namespace Abstractions.SimpleEnemy
{
    internal interface ISimpleEnemyModelSettings : ISpeed, IHealth, IPatroulingDistance,IPatrolSpeed, IDamageInterval, IDamage, IRetreatDistance,IRetreatSpeed, IMinMaxColor, IAttackDistance
    {

    }
}
