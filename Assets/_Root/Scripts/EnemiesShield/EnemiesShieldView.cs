using Abstractions.EnemiesShield;
using System;
using UnityEngine;

namespace EnemiesShield
{
    internal sealed class EnemiesShieldView : MonoBehaviour, IEnemiesShieldView
    {
        public event Action ActionOnDestroy = delegate { };

        [SerializeField] private Transform _transform;
       
        public Transform Transform => _transform;

        private void OnDestroy()
        {
            ActionOnDestroy.Invoke();
        }
    }
}
