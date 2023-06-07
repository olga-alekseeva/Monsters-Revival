using Abstractions.Enemy;
using UnityEngine;

namespace Enemy
{
    internal sealed class EnemyViewFactory : IEnemyViewFactory
    {
        public IEnemyView[] CreateFromScene()
        {
            IEnemyView[] enemyViews = GameObject.FindObjectsOfType<EnemyView>();
            return enemyViews;
        }
    }
}
