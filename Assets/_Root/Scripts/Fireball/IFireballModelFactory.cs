using UnityEngine;

namespace Abstractions.Fireball
{
    internal interface IFireballModelFactory
    {
        IFireballModel Create(Vector2 direction);
    }

}