using Abstractions.Level;
using Extension;
using UnityEngine;

namespace Level
{
    internal sealed class LevelInstantiator : ILevelInstantiator
    {
        private ILevelList _levelList;

        public LevelInstantiator(ILevelList levelList)
        {
            _levelList = levelList;
        }

        public void InstantiateRandom()
        {
            GameObject levelPrefab = _levelList.LevelPrefabArray.GetRandom();
            GameObject.Instantiate(levelPrefab);
        }
    }
}
