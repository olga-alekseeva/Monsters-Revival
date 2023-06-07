namespace Abstractions.Enemy
{
    internal interface IEnemyViewFactory
    {
        IEnemyView[] CreateFromScene();
    }
}