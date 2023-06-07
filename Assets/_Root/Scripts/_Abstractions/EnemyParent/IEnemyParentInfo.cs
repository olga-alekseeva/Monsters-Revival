using System;

namespace Abstractions.EnemyParent
{
    internal interface IEnemyParentInfo
    {
        public event Action AcionOnZeroCount;

        public void Add(IEnemyParentView view);
        public void Remove(IEnemyParentView view);
        public int GetCount();
        public void InitiateOnZeroCount();
    }
}