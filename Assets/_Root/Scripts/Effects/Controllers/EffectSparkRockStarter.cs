using Abstractions.Controllers.Effects;
using UnityEngine;

namespace Controllers.Effects
{
    internal sealed class EffectSparkRockStarter : IEffectSparkRockStarter
    {
        private const float TIME_TO_DESTROY = 1f;
        private GameObject _effectPrefab;

        public EffectSparkRockStarter(GameObject effectPrefab)
        {
            _effectPrefab = effectPrefab;
        }

        public void StartEffect(Vector3 position)
        {
            GameObject gameObject = GameObject.Instantiate(_effectPrefab, position, Quaternion.identity);
            GameObject.Destroy(gameObject, TIME_TO_DESTROY);
        }
    }
}
