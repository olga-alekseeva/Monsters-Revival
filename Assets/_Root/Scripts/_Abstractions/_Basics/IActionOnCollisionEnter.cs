using System;
using UnityEngine;

namespace Abstractions.Basics
{
    internal interface IActionOnCollisionEnter
    {
        public event Action<Collision2D> ActionOnCollisionEnter;
    }
}
