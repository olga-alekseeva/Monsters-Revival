using System;

namespace Abstractions.Basics
{
    internal interface IDestroyable
    {
        public event Action ActionOnDestroy;
    }
}
