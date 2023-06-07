using Abstractions.Level;
using UnityEngine;

namespace Level
{
    [CreateAssetMenu(fileName = nameof(LevelList), menuName = "ScriptableObject/" + nameof(LevelList))]
    internal sealed class LevelList : ScriptableObject, ILevelList
    {
        [SerializeField] private GameObject[] _levelPrefabArray;

        public GameObject[] LevelPrefabArray => _levelPrefabArray;
    }
}
