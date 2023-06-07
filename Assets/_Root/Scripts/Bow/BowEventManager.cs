using Abstractions.Bow;
using Abstractions.Enemy;
using Bow;
using System;
using System.Collections.Generic;

namespace MonstersRevival
{
    internal sealed class BowEventManager : IBowEventManager
    {
        public event Action<IBowModel, IBowView> ActionOnInstantiated = delegate { };
        public event Action<IBowModel, IBowView> ActionOnDestroyed = delegate { };
        private Dictionary<IBowView, IBowModel> _dictionary;
        public BowEventManager()
        {
            _dictionary = new Dictionary<IBowView, IBowModel>();
        }

        public void Instantiated(IBowModel bowModel, IBowView bowView)
        {
            bowView.ActionOnDestroyView += Destroyed;
            _dictionary.Add(bowView, bowModel);
            ActionOnInstantiated.Invoke(bowModel, bowView);
        }

        public void Destroyed(IBowView bowView)
        {
            bowView.ActionOnDestroyView -= Destroyed;
            ActionOnDestroyed.Invoke(_dictionary[bowView], bowView);
            _dictionary.Remove(bowView);
        }
    }
}
