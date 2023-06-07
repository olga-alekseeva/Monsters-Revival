using Abstractions.Effects;
using System;
using UnityEngine;

namespace Effects
{

    internal sealed class EffectEventManager : IEffectEventManager
    {
        public event Action<Vector3> ActionHitEffect = delegate { };

        public void StartHitEffect(Vector3 position)
        {
            ActionHitEffect.Invoke(position);
        }
    }
}
