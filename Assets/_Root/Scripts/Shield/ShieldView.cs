using Abstractions.Shield;
using System;
using UnityEngine;

namespace Shield
{
    internal sealed class ShieldView : MonoBehaviour, IShieldView
    {
        [SerializeField] private Transform _transform;

        public Transform Transform => _transform;

        public event Action ActionOnDestroy = delegate { };

        private void OnDestroy()
        {
            ActionOnDestroy.Invoke();
        }
    }
}
