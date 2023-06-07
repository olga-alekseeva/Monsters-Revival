using Abstractions.Portal;
using System;
using UnityEngine;

namespace Portal
{
    internal sealed class PortalView : MonoBehaviour, IPortalView
    {
        [SerializeField] private GameObject _gameObject;

        public GameObject GameObject => _gameObject;

        public event Action ActionOnDestroy = delegate { };

        private void OnDestroy()
        {
            ActionOnDestroy.Invoke();
        }
    }
}
