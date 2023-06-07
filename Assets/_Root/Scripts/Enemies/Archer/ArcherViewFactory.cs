using Abstractions.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    internal sealed class ArcherViewFactory : IArcherViewFactory
    {
        public IArcherView[] CreateFromScene()
        {
            IArcherView[] archerViews = GameObject.FindObjectsOfType<ArcherView>();
            return archerViews;
        }
    }
}
