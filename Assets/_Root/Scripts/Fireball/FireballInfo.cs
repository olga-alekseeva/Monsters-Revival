using Abstractions.Enemy;
using Abstractions.Fireball;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Fireball
{
    internal sealed class FireballInfo : IFireballInfo
    {
        public event Action<IFireballModel, IFireballView> ActionOnInstantiated = delegate { };
        public event Action<IFireballModel, IFireballView> ActionOnDestroyed = delegate { };

        private Dictionary<IFireballView, IFireballModel> _dictionary;

        private IFireballSettings _fireballSettings;

        public IFireballSettings FireballSettings => _fireballSettings;

        public FireballInfo(IFireballSettings fireballSettings)
        {
            _dictionary = new Dictionary<IFireballView, IFireballModel>();
            _fireballSettings = fireballSettings;
        }

        public bool IsPreset()
        {
            return _dictionary.Count > 0;
        }

        public void FireballInstantiated(IFireballModel model, IFireballView view)
        {
            view.ActionOnDestroyView += FireballDestroyed;
            _dictionary.Add(view, model);
            ActionOnInstantiated.Invoke(model, view);
        }

        public void FireballDestroyed(IFireballView view)
        {
            view.ActionOnDestroyView -= FireballDestroyed;
            ActionOnDestroyed.Invoke(_dictionary[view], view);
            _dictionary.Remove(view);
        }

        public Transform GetNearestFireball(Transform transform)
        {
            Transform result = null;
            float minSqrMagnitude = 0;
            foreach (KeyValuePair<IFireballView, IFireballModel> keyValuePair in _dictionary)
            {
                float sqrMagnitude = (transform.position - keyValuePair.Key.Transform.position).sqrMagnitude;
                if ((sqrMagnitude < minSqrMagnitude) || (result == null))
                {
                    result = keyValuePair.Key.Transform;
                    minSqrMagnitude = sqrMagnitude;
                }
            }
            return result;
        }

        public void DestroyFirst()
        {
            if (!IsPreset()) return;
            IFireballView firstView = _dictionary.First().Key;
            GameObject.Destroy(firstView.GameObject);
        }
    }
}
