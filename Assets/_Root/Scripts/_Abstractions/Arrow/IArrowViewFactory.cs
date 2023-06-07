using UnityEngine;

namespace Abstractions.Arrow
{
    internal interface IArrowViewFactory
    {
        public IArrowView Create(Vector3 position, Quaternion direction);
    }
}