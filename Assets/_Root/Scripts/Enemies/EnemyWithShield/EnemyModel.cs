using Abstractions.Enemy;
using UnityEngine;

namespace Enemy
{
    internal sealed class EnemyModel : IEnemyModel
    {
        private IEnemyModelSettings _enemyModelSettings;
        private float _health;

        public IEnemyModelSettings EnemyModelSettings => _enemyModelSettings;

        public float Health { get => _health; set => _health = value; }

        public float CurrentHealth => _health;

        public float MaxHealth => _enemyModelSettings.Health;

        public Color MinColor => _enemyModelSettings.MinColor;

        public Color MaxColor => _enemyModelSettings.MaxColor;

        public EnemyModel (IEnemyModelSettings enemyModelSettings)
        {
            _enemyModelSettings = enemyModelSettings;
            _health = enemyModelSettings.Health;
        }
    }
}
