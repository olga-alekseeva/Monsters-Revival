using Abstractions.Basics;
using Abstractions.Enemy;
using Arrow;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abstractions.Arrow
{
    internal interface IArrowEventManager
{
        event Action<IArrowModel, IArrowView> ActionOnDestroyed;
        event Action<IArrowModel, IArrowView> ActionOnInstantiated;
        event Action<Vector3, Quaternion, float> ActionFireStart;

        void Instantiated(IArrowModel arrowModel, IArrowView arrowView);
        void Destroyed(IArrowView arrowView);

        public void FireStart(Vector3 position, Quaternion direction, float shootingForce);
    }
}
