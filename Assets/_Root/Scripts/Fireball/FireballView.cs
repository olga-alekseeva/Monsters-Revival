using Abstractions.Fireball;
using System;
using UnityEngine;

namespace Fireball
{
    internal sealed class FireballView : MonoBehaviour, IFireballView
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private GameObject _gameObject;

        public event Action ActionOnDestroy = delegate { };
        public event Action<IFireballView> ActionOnDestroyView = delegate { };
        public event Action<Collider2D> ActionOnTriggerEnter = delegate { };
        public event Action<Collision2D> ActionOnCollisionEnter = delegate { };

        public Transform Transform => _transform;

        public Rigidbody2D Rigidbody => _rigidbody;

        public GameObject GameObject => _gameObject;

        private void OnDestroy()
        {
            ActionOnDestroyView.Invoke(this);
            ActionOnDestroy.Invoke();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            ActionOnTriggerEnter.Invoke(collision);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            ActionOnCollisionEnter.Invoke(collision);
        }
    }
}
