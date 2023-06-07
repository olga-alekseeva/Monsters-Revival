using System;
using UnityEngine;

namespace Abstractions.Basics
{
    internal interface IActionOnCollisionStay
    {
        public event Action<Collision2D> ActionOnCollisionStay;
    }
}
