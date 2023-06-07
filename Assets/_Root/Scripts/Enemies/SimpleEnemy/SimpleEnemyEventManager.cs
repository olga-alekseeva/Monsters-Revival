using Abstractions.Basics;
using Abstractions.SimpleEnemy;
using System;
using System.Collections.Generic;

namespace SimpleEnemy
{
    internal sealed class SimpleEnemyEventManager : ISimpleEnemyEventManager
    {
        public event Action<ISimpleEnemyModel, ISimpleEnemyView> ActionOnDestroyed = delegate { };
        public event Action<ISimpleEnemyModel, ISimpleEnemyView> ActionOnInstantiated = delegate { };
        public event Action<ISimpleEnemyModel, ISimpleEnemyView, IDamage> ActionOnDamageReceived = delegate { };
        private Dictionary<ISimpleEnemyView, ISimpleEnemyModel> _dictionary;

        public SimpleEnemyEventManager()
        {
            _dictionary = new Dictionary<ISimpleEnemyView, ISimpleEnemyModel>();
        }

        public void Instantiated(ISimpleEnemyModel simpleEnemyModel, ISimpleEnemyView simpleEnemyView)
        {
            simpleEnemyView.ActionOnDestroyView += Destroyed;
            _dictionary.Add(simpleEnemyView, simpleEnemyModel);
            ActionOnInstantiated.Invoke(simpleEnemyModel, simpleEnemyView);
        }
        public void DamageReceived(ISimpleEnemyView simpleEnemyView, IDamage damage)
        {
            ActionOnDamageReceived.Invoke(_dictionary[simpleEnemyView], simpleEnemyView, damage);
        }

        public void Destroyed(ISimpleEnemyView simpleEnemyView)
        {
            simpleEnemyView.ActionOnDestroyView -= Destroyed;
            ActionOnDestroyed.Invoke(_dictionary[simpleEnemyView], simpleEnemyView);
            _dictionary.Remove(simpleEnemyView);
        }

    }
}
