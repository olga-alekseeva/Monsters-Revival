using System;

namespace Abstractions.Basics
{
    internal interface IEvent<T1, T2>
    {
        public event Action<T1, T2> Action;

        public void Initiate(T1 t1, T2 t2);
    }
}