using System;
using UnityEngine;

namespace Abstractions.Controllers
{
    internal interface IFireBallReflectionDamageSetter
    {
        public event Action<Vector3> ActionHitEffect;

        void ActionOnCollisionEnter(Collision2D collision);
    }
}