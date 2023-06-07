using Abstractions.Bow;
using System;

namespace Abstractions.Bow
{
    internal interface IBowEventManager
    {
        event Action<IBowModel, IBowView> ActionOnDestroyed;
        event Action<IBowModel, IBowView> ActionOnInstantiated;

        void Destroyed(IBowView bowView);
        void Instantiated(IBowModel bowModel, IBowView bowView);
    }
}