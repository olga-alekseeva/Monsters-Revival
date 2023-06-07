using Abstractions.Basics;
using System;

namespace Abstractions.Enemy
{
    internal interface IArcherEventManager
    {
        event Action<IArcherModel, IArcherView> ActionOnDestroyed;
        event Action<IArcherModel, IArcherView> ActionOnInstantiated;
        public event Action<IArcherModel, IArcherView, IDamage> ActionOnDamageReceived;

        void Destroyed(IArcherView archerView);
        void Instantiated(IArcherModel archerModel, IArcherView archerView);
        public void DamageReceived(IArcherView archerView, IDamage damage);
    }
}
