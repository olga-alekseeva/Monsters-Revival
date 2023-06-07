using Abstractions.Basics;
using Abstractions.EnemyParent;

namespace Abstractions.Enemy
{
    internal interface IArcherView : IEnemyParentView, 
        IRigidbody, ITransform,
        IGameObject, IDestroyable, IDestroyableView<IArcherView>, IDamageable, IHealthBarHolder, IArrowStart
    {
        
    }
}
