using Abstractions.Fireball;
using UnityEngine;

namespace Fireball
{
    internal class FireballModel : IFireballModel
    {
        private Vector2 _direction;
        private float _radius;
        private float _damage;
        private float _damageIncrementStep;
        private float _speed;


        public Vector2 Direction { get => _direction; set => _direction = value; }

        public float Radius { get => _radius; set => _radius = value; }

        public float Damage => _damage;
        public float Speed => _speed;

        public float DamageIncrementStep => _damageIncrementStep;

        public FireballModel(Vector2 startDirection, IFireballSettings fireballSettings)
        {
            _direction = startDirection.normalized;
            _radius = fireballSettings.Radius;
            _damage = fireballSettings.Damage;
            _speed = fireballSettings.Speed;
            _damageIncrementStep = fireballSettings.DamageIncrementStep;
        }

        public void SetDamage(float value)
        {
            _damage = value;
        }
    }
}
