using Abstractions.Basics;
using Abstractions.Enemy;
using System;
using UnityEngine;

namespace Enemy
{
    internal sealed class ArcherView : MonoBehaviour, IArcherView
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Transform _transform;
        [SerializeField] private GameObject _gameObject;
        [SerializeField] private Transform _healthBarRoot;
        [SerializeField] private Transform _arrowStart;
        public Rigidbody2D Rigidbody => _rigidbody;

        public Transform Transform => _transform;

        public GameObject GameObject => _gameObject;

        public Transform HealthBarRoot => _healthBarRoot;

        public Transform ArrowStart => _arrowStart;

        public event Action ActionOnDestroy = delegate { };
        public event Action<IArcherView> ActionOnDestroyView = delegate { };
        public event Action<IDamage> ActionOnSetDamage = delegate { };

        public void SetDamage(IDamage damage)
        {
            ActionOnSetDamage.Invoke(damage);
        }
        private void OnDestroy()
        {
            ActionOnDestroyView.Invoke(this);
            ActionOnDestroy.Invoke();
        }
    }
}
