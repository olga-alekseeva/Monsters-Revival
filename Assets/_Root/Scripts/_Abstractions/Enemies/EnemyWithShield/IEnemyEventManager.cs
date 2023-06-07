using Abstractions.Basics;
using System;

namespace Abstractions.Enemy
{
    internal interface IEnemyEventManager
    {
        event Action<IEnemyModel, IEnemyView> ActionOnDestroyed;
        event Action<IEnemyModel, IEnemyView> ActionOnInstantiated;
        public event Action<IEnemyModel, IEnemyView, IDamage> ActionOnDamageReceived;
        void Destroyed(IEnemyView enemyView);
        void Instantiated(IEnemyModel enemyModel, IEnemyView enemyView);
        public void DamageReceived(IEnemyView enemyView, IDamage damage);
    }
}