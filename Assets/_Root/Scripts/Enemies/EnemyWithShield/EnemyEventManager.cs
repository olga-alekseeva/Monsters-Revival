using Abstractions.Basics;
using Abstractions.Enemy;
using System;
using System.Collections.Generic;

namespace Enemy
{
    internal sealed class EnemyEventManager : IEnemyEventManager
    {
        public event Action<IEnemyModel, IEnemyView> ActionOnInstantiated = delegate { };
        public event Action<IEnemyModel, IEnemyView> ActionOnDestroyed = delegate { };
        public event Action<IEnemyModel, IEnemyView, IDamage> ActionOnDamageReceived = delegate { };

        private Dictionary<IEnemyView, IEnemyModel> _dictionary;

        public EnemyEventManager()
        {
            _dictionary = new Dictionary<IEnemyView, IEnemyModel>();
        }

        public void Instantiated(IEnemyModel enemyModel, IEnemyView enemyView)
        {
            enemyView.ActionOnDestroyView += Destroyed;
            _dictionary.Add(enemyView, enemyModel);
            ActionOnInstantiated.Invoke(enemyModel, enemyView);
        }

        public void Destroyed(IEnemyView enemyView)
        {
            enemyView.ActionOnDestroyView -= Destroyed;
            ActionOnDestroyed.Invoke(_dictionary[enemyView], enemyView);
            _dictionary.Remove(enemyView);
        }

        public void DamageReceived(IEnemyView enemyView, IDamage damage)
        {
            ActionOnDamageReceived.Invoke(_dictionary[enemyView], enemyView, damage);
        }
    }
}
