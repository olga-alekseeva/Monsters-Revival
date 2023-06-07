using Fireball;
using System;
using System.Numerics;
using UnityEngine;

namespace Abstractions.Fireball
{
    internal interface IFireballInfo
    {
        public event Action<IFireballModel, IFireballView> ActionOnInstantiated;
        public event Action<IFireballModel, IFireballView> ActionOnDestroyed;

        public IFireballSettings FireballSettings { get; }
        public bool IsPreset();
        public void FireballInstantiated(IFireballModel model, IFireballView view);

        public void FireballDestroyed(IFireballView view);
        public Transform GetNearestFireball(Transform position);
        public void DestroyFirst();
        
    }
}