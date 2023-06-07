using Abstractions.Arrow;
using Abstractions.Basics;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arrow
{
    internal sealed class ArrowView : MonoBehaviour, IArrowView
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private GameObject _gameobject;
        public Transform Transform => _transform;

        public Rigidbody2D Rigidbody => _rigidbody;

        public GameObject GameObject => _gameobject;

        public Transform MoveTransform => _transform;

        public event Action ActionOnDestroy = delegate { };
        public event Action<IDamage> ActionOnSetDamage = delegate { };

        public event Action<Collider2D> ActionOnTriggerEnter = delegate { };
        public event Action<Collision2D> ActionOnCollisionEnter = delegate { };

        public void SetDamage(IDamage damage)
        {
            ActionOnSetDamage.Invoke(damage);
        }

        private void OnDestroy()
        {
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
