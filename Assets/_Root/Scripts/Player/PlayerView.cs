using Abstractions.Basics;
using Abstractions.Player;
using System;
using UnityEngine;

namespace Player
{
    internal sealed class PlayerView : MonoBehaviour, IPlayerView
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private Transform _healthBarRoot;
        [SerializeField] private Transform _spawnTransform;

        public event Action ActionOnDestroy = delegate { };
        public event Action<IDamage> ActionOnSetDamage = delegate { };
        public event Action<Collider2D> ActionOnTriggerEnter = delegate { };

        public Rigidbody2D Rigidbody => _rigidbody;
        public Transform Transform => _playerTransform;

        public Transform HealthBarRoot => _healthBarRoot;
        public Transform SpawnTransform => _spawnTransform;

        private void OnDestroy()
        {
            ActionOnDestroy.Invoke();
        }

        public void SetDamage(IDamage damage)
        {
            ActionOnSetDamage.Invoke(damage);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            ActionOnTriggerEnter.Invoke(collision);
        }
    }
}
