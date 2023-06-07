using Abstractions.SimpleEnemy;
using UnityEngine;

namespace SimpleEnemy
{
    internal sealed class SimpleEnemyModel : ISimpleEnemyModel
    {
        private ISimpleEnemyModelSettings _simpleEnemyModelSettings;
        private float _health;

        public ISimpleEnemyModelSettings SimpleEnemyModelSettings => _simpleEnemyModelSettings;

        public float Health { get => _health; set => _health = value; }

        public float CurrentHealth => _health;

        public float MaxHealth => _simpleEnemyModelSettings.Health;

        public Color MinColor => _simpleEnemyModelSettings.MinColor;

        public Color MaxColor => _simpleEnemyModelSettings.MaxColor;
        public SimpleEnemyModel(ISimpleEnemyModelSettings simpleEnemyModelSettings)
        {
            _simpleEnemyModelSettings = simpleEnemyModelSettings;
            _health = simpleEnemyModelSettings.Health;
        }
    }
}
