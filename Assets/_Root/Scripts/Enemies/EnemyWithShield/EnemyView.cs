using Abstractions.Basics;
using Abstractions.Enemy;
using System;
using UnityEngine;

namespace Enemy
{
    internal sealed class EnemyView : MonoBehaviour, IEnemyView
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Transform _transform;
        [SerializeField] private GameObject _gameObject;
        [SerializeField] private Transform _healthBarRoot;
        public Rigidbody2D Rigidbody => _rigidbody;
        public Transform Transform => _transform;

        public GameObject GameObject => _gameObject;

        public Transform HealthBarRoot => _healthBarRoot;

        public event Action ActionOnDestroy = delegate { };
        public event Action<IEnemyView> ActionOnDestroyView = delegate { };
        public event Action<IDamage> ActionOnSetDamage = delegate { };
        public event Action<Collision2D> ActionOnCollisionEnter = delegate { };
        public event Action<Collision2D> ActionOnCollisionStay = delegate { };
        public void SetDamage(IDamage damage)
        {
            ActionOnSetDamage.Invoke(damage);
        }
        private void OnDestroy()
        {
            ActionOnDestroyView.Invoke(this);
            ActionOnDestroy.Invoke();
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            ActionOnCollisionEnter.Invoke(collision);
        }
        private void OnCollisionStay2D(Collision2D collision)
        {
            ActionOnCollisionStay.Invoke(collision);
        }
    }
}
