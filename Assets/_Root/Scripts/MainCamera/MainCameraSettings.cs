using Abstractions.Basics;
using UnityEngine;

namespace MonstersRevival
{
    [CreateAssetMenu(fileName = nameof(MainCameraSettings), menuName = "ScriptableObject/" + nameof(MainCameraSettings))]
    internal sealed class MainCameraSettings : ScriptableObject, IMainCameraSettings
    {
        [SerializeField] float _speed;
        public float Speed => _speed;
    }
}
