using Abstractions.Basics;
using Abstractions.Enemy;
using System;
using System.Collections.Generic;

namespace Enemy
{
    internal sealed class ArcherEventManager : IArcherEventManager
    {
        public event Action<IArcherModel, IArcherView> ActionOnDestroyed = delegate { };
        public event Action<IArcherModel, IArcherView> ActionOnInstantiated = delegate { };
        public event Action<IArcherModel, IArcherView, IDamage> ActionOnDamageReceived = delegate { };

        private Dictionary<IArcherView, IArcherModel> _dictionary;

        public ArcherEventManager()
        {
            _dictionary = new Dictionary<IArcherView, IArcherModel>();
        }
        public void Instantiated(IArcherModel archerModel, IArcherView archerView)
        {
            archerView.ActionOnDestroyView += Destroyed;
            _dictionary.Add(archerView, archerModel);
            ActionOnInstantiated.Invoke(archerModel, archerView);
        }
        public void DamageReceived(IArcherView archerView, IDamage damage)
        {
            ActionOnDamageReceived.Invoke(_dictionary[archerView], archerView, damage);
        }

        public void Destroyed(IArcherView archerView)
        {
            archerView.ActionOnDestroyView -= Destroyed;
            ActionOnDestroyed.Invoke(_dictionary[archerView], archerView);
            _dictionary.Remove(archerView);
        }
    }
}
