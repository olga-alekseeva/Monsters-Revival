using Abstractions.Fireball;
using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(fileName = nameof(FireballSettings), menuName = "ScriptableObject/" + nameof(FireballSettings))]
    public class FireballSettings : ScriptableObject, IFireballSettings
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _damage;
        [SerializeField] private float _radius;
        [SerializeField] private float _damageIncrementStep;
        [SerializeField] private int _countOfLaunches;
        public float Speed => _speed;

        public float Damage => _damage;

        public float Radius { get => _radius; set { } }

        public float DamageIncrementStep => _damageIncrementStep;

        public int CountOfLaunches { get => _countOfLaunches; set { } }
    } 
}
