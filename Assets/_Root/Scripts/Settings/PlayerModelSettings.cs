using Abstractions.Player;
using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(fileName = nameof(PlayerModelSettings), menuName = "ScriptableObject/" + nameof(PlayerModelSettings))]
    public class PlayerModelSettings : ScriptableObject, IPlayerModelSettings
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _health;
        [SerializeField] private float _rotateSpeed;
        [SerializeField] private Color _minColor;
        [SerializeField] private Color _maxColor;

        public float Speed => _speed;

        public float Health { get => _health; set { } }

        public float RotateSpeed => _rotateSpeed;

        public Color MinColor => _minColor;

        public Color MaxColor => _maxColor;
    }
}
