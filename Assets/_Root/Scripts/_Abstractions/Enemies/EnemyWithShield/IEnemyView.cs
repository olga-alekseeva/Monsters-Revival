using Abstractions.Basics;
using Abstractions.EnemyParent;

namespace Abstractions.Enemy
{
    internal interface IEnemyView : IEnemyParentView, IRigidbody, ITransform, IGameObject, IDestroyable, IDestroyableView<IEnemyView>, IDamageable, IActionOnCollisionEnter, IActionOnCollisionStay, IHealthBarHolder
    {
        
    }
}
