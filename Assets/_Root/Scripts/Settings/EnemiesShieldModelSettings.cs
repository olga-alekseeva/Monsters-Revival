using Abstractions.EnemiesShield;
using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(fileName = nameof(EnemiesShieldModelSettings), menuName = "ScriptableObject/" + nameof(EnemiesShieldModelSettings))]

    public class EnemiesShieldModelSettings : ScriptableObject, IEnemiesShieldModelSettings
    {
        [SerializeField] private float _speed;
        public float Speed => _speed;
    }
}
