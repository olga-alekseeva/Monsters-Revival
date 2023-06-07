using Abstractions.Fireball;
using UnityEngine;

namespace Fireball
{
    internal class FireballModelFactory : IFireballModelFactory
    {
        private IFireballSettings _fireballSettings;
        public FireballModelFactory(IFireballSettings fireballSettings)
        {
            _fireballSettings = fireballSettings;
        }

        public IFireballModel Create(Vector2 direction)
        {
            IFireballModel model = new FireballModel(direction, _fireballSettings);
            return model;
        }
    }
}
