using Abstractions.Basics;

namespace Abstractions.Bow
{
    internal interface IBowModelSettings : ISpeed, IAttackDistance, IDirection,IWaitTime,IDelay, IDamage, IDamageInterval
    {

    }
}
