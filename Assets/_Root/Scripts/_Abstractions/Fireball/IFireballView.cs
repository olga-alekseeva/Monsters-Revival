using Abstractions.Basics;
using System;
using UnityEngine;

namespace Abstractions.Fireball
{
    internal interface IFireballView : ITransform, IRigidbody,IGameObject, IDestroyable, IActionOnTriggerEnter, IActionOnCollisionEnter, IDestroyableView<IFireballView>
    {

    }
}

