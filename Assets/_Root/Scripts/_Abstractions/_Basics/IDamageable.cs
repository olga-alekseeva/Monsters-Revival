using System;

namespace Abstractions.Basics
{
    internal interface IDamageable
    {
        public event Action<IDamage> ActionOnSetDamage;

        public void SetDamage(IDamage damage);
    }
}
