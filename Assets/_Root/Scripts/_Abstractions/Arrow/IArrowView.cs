using Abstractions.Basics;
using System;
using UnityEngine;

namespace Abstractions.Arrow
{
    internal interface IArrowView : ITransform,IRigidbody,
        IDestroyable,IGameObject, IDamageable, IActionOnTriggerEnter, IActionOnCollisionEnter
    {
    }
}
