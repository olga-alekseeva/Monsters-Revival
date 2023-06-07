using Abstractions.Basics;
using Abstractions.Enemy;

namespace Abstractions.Bow
{
    internal interface IBowView : ITransform, IDestroyable, IGameObject, IDestroyableView<IBowView>
    {
       
    }
}
