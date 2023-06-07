using UnityEngine;

namespace Abstractions.Level
{
    internal interface ILevelList
    {
        GameObject[] LevelPrefabArray { get; }
    }
}