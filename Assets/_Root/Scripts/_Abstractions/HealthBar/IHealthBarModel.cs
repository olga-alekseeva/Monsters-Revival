using UnityEngine;

namespace Abstractions.HealthBar
{
    internal interface IHealthBarModel
    {
        public float CurrentHealth { get; }
        public float MaxHealth { get; }

        public Color MinColor { get; }
        public Color MaxColor { get; }
    }
}