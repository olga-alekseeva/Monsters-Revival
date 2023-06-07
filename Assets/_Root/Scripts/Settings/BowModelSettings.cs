using Abstractions.Bow;
using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(fileName = nameof(BowModelSettings), menuName = "ScriptableObject/" + nameof(BowModelSettings))]
    public class BowModelSettings : ScriptableObject, IBowModelSettings
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _attackDistance;
        [SerializeField] private Vector2 _direction;
        [SerializeField] private float _waitTime;
        [SerializeField] private float _delay;
        [SerializeField] private float _damage;
        [SerializeField] private float _damageInterval;
        public float Speed => _speed;

        public float AttackDistance { get => _attackDistance; }

        public Vector2 Direction { get => _direction; set { } }
        public float WaitTime { get => _waitTime; set { } }

        public float Delay { get => _delay; }

        public float Damage { get => _damage; }

        public float DamageInterval { get => _damageInterval; }
    }
}
