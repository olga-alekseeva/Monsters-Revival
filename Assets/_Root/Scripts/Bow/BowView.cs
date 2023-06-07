using Abstractions.Bow;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bow
{
    internal sealed class BowView : MonoBehaviour, IBowView
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private GameObject _gameObject;

        public Transform Transform => _transform;

        public GameObject GameObject => _gameObject;

        public event Action ActionOnDestroy = delegate { };
        public event Action<IBowView> ActionOnDestroyView = delegate { };

        private void OnDestroy()
        {
            ActionOnDestroyView.Invoke(this);
            ActionOnDestroy.Invoke();
        }
    }
}
