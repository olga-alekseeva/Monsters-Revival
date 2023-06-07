using Abstractions.Arrow;
using UnityEngine;

namespace Arrow
{
    internal sealed class ArrowViewFactory : IArrowViewFactory
    {
        private GameObject _prefab;

        public ArrowViewFactory(GameObject prefab)
        {
            _prefab = prefab;
        }

        public IArrowView Create(Vector3 position, Quaternion direction)
        {
            GameObject gameObject = GameObject.Instantiate(_prefab, position, direction);
            IArrowView arrowView = gameObject.GetComponent<ArrowView>();
            return arrowView;
        }
    }
}
