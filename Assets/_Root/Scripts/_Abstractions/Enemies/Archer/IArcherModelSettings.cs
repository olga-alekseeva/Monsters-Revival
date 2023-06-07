using Abstractions.Basics;

namespace Abstractions.Enemy
{
    internal interface IArcherModelSettings : ISpeed,IHealth, IPatroulingDistance, IAttackDistance, IMinMaxColor, IPatrolSpeed, IRetreatDistance, IRetreatSpeed, IShootingForce, IShootingInterfval
    {
       
    }
}
