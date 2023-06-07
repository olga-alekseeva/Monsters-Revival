using System;
using UnityEngine;

namespace Abstractions.Basics
{
    internal interface IActionOnTriggerEnter
    {
        public event Action<Collider2D> ActionOnTriggerEnter;
    }
}
