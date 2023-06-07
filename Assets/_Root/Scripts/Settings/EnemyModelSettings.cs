using Abstractions.Basics;
using Abstractions.Enemy;
using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(fileName = nameof(EnemyModelSettings), menuName = "ScriptableObject/" + nameof(EnemyModelSettings))]
    public class EnemyModelSettings : ScriptableObject, IEnemyModelSettings
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _patrolSpeed;
        [SerializeField] private float _minDistance;
        [SerializeField] private float _patroulingDistance;
        [SerializeField] private float _health;
        [SerializeField] private float _attackDistance;
        [SerializeField] private float _damage;
        [SerializeField] private float _damageInterval;
        [SerializeField] private Color _minColor;
        [SerializeField] private Color _maxColor;

        public float Speed => _speed;
        public float MinDistance => _minDistance;

        public float Health { get => _health; set { } }

        public float PatroulingDistance => _patroulingDistance;

        public float AttackDistance => _attackDistance;

        public float Damage => _damage;

        public float DamageInterval => _damageInterval;

        public Color MinColor => _minColor;

        public Color MaxColor => _maxColor;

        public float PatrolSpeed => _patrolSpeed;
    }
}
