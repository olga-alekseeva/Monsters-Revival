using Abstractions.Arrow;
using UnityEngine;


namespace Settings
{
    [CreateAssetMenu(fileName = nameof(ArrowModelSettings), menuName = "ScriptableObject/" + nameof(ArrowModelSettings))]
    public class ArrowModelSettings : ScriptableObject, IArrowModelSettings
    {
        [SerializeField] private float _speed;
        public float Speed => _speed;

    }
}
