using Abstractions.EnemyParent;
using System;
using System.Collections.Generic;

namespace EnemyParent
{
    internal sealed class EnemyParentInfo : IEnemyParentInfo
    {
        public event Action AcionOnZeroCount = delegate { };

        private List<IEnemyParentView> _enemyParentViews;

        public EnemyParentInfo()
        {
            _enemyParentViews = new List<IEnemyParentView>();
        }

        public void Add(IEnemyParentView view)
        {
            _enemyParentViews.Add(view);
        }

        public void Remove(IEnemyParentView view)
        {
            _enemyParentViews.Remove(view);
        }

        public int GetCount()
        {
            return _enemyParentViews.Count;
        }

        public void InitiateOnZeroCount()
        {
            AcionOnZeroCount.Invoke();
        }
    }
}
