using System;
using UnityEngine;

namespace Abstractions.Effects
{
    internal interface IEffectEventManager
    {
        event Action<Vector3> ActionHitEffect;

        void StartHitEffect(Vector3 position);
    }


}
