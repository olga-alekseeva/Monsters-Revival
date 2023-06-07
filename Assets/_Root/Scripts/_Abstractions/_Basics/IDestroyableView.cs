using System;

namespace Abstractions.Basics
{
    internal interface IDestroyableView<T>
    {
        public event Action<T> ActionOnDestroyView;
    }
}
