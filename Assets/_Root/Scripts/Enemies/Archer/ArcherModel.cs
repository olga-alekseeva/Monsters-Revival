using Abstractions.Enemy;
using UnityEngine;

namespace Enemy
{
    internal sealed class ArcherModel : IArcherModel
    {
        private IArcherModelSettings _archerModelsettings;
        private float _health;
        public IArcherModelSettings ArcherModelSettings => _archerModelsettings;

        public float Health { get => _health; set => _health = value; }

        public float CurrentHealth => _health;

        public float MaxHealth => _archerModelsettings.Health;

        public Color MinColor => _archerModelsettings.MinColor;

        public Color MaxColor => _archerModelsettings.MaxColor;

        public ArcherModel(IArcherModelSettings archerModelSettings)
        {
            _archerModelsettings = archerModelSettings;
            _health = archerModelSettings.Health;
        }


    }
}
