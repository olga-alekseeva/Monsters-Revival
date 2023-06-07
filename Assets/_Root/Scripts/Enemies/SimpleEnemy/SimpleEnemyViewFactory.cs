using Abstractions.SimpleEnemy;
using UnityEngine;

namespace SimpleEnemy
{
    internal sealed class SimpleEnemyViewFactory : ISimpleEnemyViewFactory
    {
        public ISimpleEnemyView[] CreateFromScene()
        {
            ISimpleEnemyView[] simpleEnemyViews = GameObject.FindObjectsOfType<SimpleEnemyView>();
            return simpleEnemyViews;
        }
    }
}
