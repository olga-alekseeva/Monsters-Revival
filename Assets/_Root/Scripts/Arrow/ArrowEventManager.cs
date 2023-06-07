using Abstractions.Arrow;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Arrow
{
    internal sealed class ArrowEventManager : IArrowEventManager
    {
        public event Action<IArrowModel, IArrowView> ActionOnDestroyed = delegate { };
        public event Action<IArrowModel, IArrowView> ActionOnInstantiated = delegate { };
        public event Action<Vector3, Quaternion, float> ActionFireStart = delegate { };



        private Dictionary<IArrowView, IArrowModel> _dictionary;
        public ArrowEventManager()
        {
            _dictionary = new Dictionary<IArrowView, IArrowModel>();
        }
        public void Instantiated(IArrowModel arrowModel, IArrowView arrowView)
        {
            _dictionary.Add(arrowView, arrowModel);
            ActionOnInstantiated.Invoke(arrowModel, arrowView);
        }

        public void Destroyed(IArrowView arrowView)
        {
            ActionOnDestroyed.Invoke(_dictionary[arrowView], arrowView);
            _dictionary.Remove(arrowView);
        }

        public void FireStart(Vector3 position, Quaternion direction, float shootingForce)
        {
            ActionFireStart.Invoke(position, direction, shootingForce);
        }

    }
}
