using Abstractions.Basics;
using System;

namespace Abstractions.SimpleEnemy
{
    internal interface ISimpleEnemyEventManager
    {
        event Action<ISimpleEnemyModel, ISimpleEnemyView> ActionOnDestroyed;
        event Action<ISimpleEnemyModel, ISimpleEnemyView> ActionOnInstantiated;
        public event Action<ISimpleEnemyModel, ISimpleEnemyView, IDamage> ActionOnDamageReceived;
        void Destroyed(ISimpleEnemyView simpleEnemyView);
        void Instantiated(ISimpleEnemyModel simpleEnemyModel, ISimpleEnemyView simpleEnemyView);
        public void DamageReceived(ISimpleEnemyView simpleEnemyView, IDamage damage);
    }
}
