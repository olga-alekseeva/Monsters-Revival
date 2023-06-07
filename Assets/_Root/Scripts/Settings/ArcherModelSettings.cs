using Abstractions.Enemy;
using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(fileName = nameof(ArcherModelSettings), menuName = "ScriptableObject/" + nameof(ArcherModelSettings))]

    public class ArcherModelSettings : ScriptableObject, IArcherModelSettings
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
        [SerializeField] private float _shootingForce;
        [SerializeField] private float _shootingInterval;

        public float Speed => _speed;
        public float Health { get => _health; set { } }

        public float PatroulingDistance => _patroulingDistance;

        public float AttackDistance => _attackDistance;

        public Color MinColor => _minColor;

        public Color MaxColor => _maxColor;

        public float PatrolSpeed => _patrolSpeed;

        public float RetreatDistance => _retreatDistance;

        public float RetreatSpeed => _retreatSpeed;

        public float ShootingForce => _shootingForce;

        public float ShootingInterval => _shootingInterval;
    }
}
