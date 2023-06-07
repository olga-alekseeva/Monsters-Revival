using Abstractions.SimpleEnemy;
using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(fileName = nameof(SimpleEnemyModelSettings), menuName = "ScriptableObject/" + nameof(SimpleEnemyModelSettings))]
    public class SimpleEnemyModelSettings : ScriptableObject, ISimpleEnemyModelSettings
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _patroulingDistance;
        [SerializeField] private float _health;
        [SerializeField] private float _attackDistance;
        [SerializeField] private float _patrolSpeed;
        [SerializeField] private float _retreatDistance;
        [SerializeField] private float _retreatSpeed;
        [SerializeField] private Color _minColor;
        [SerializeField] private Color _maxColor;
        [SerializeField] private float _damageInterval;
        [SerializeField] private float _damage;
        public float Speed => _speed;
        public float AttackDistance => _attackDistance;
        public float Health { get => _health; set { } }

        public float PatroulingDistance => _patroulingDistance;

        public float PatrolSpeed => _patrolSpeed;

        public float RetreatDistance => _retreatDistance;
        public float RetreatSpeed => _retreatSpeed;

        public Color MinColor => _minColor;

        public Color MaxColor => _maxColor;

        public float DamageInterval => _damageInterval;

        public float Damage => _damage;
    }
}
