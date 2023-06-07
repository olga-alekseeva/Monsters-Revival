using Abstractions.Basics;
using Abstractions.EnemyParent;

namespace Abstractions.SimpleEnemy
{
    internal interface ISimpleEnemyView : IEnemyParentView,
        IRigidbody, ITransform, IGameObject, IDestroyable,
        IDestroyableView<ISimpleEnemyView>, IDamageable,
        IActionOnCollisionEnter, IActionOnCollisionStay, IHealthBarHolder
    {

    }
}
