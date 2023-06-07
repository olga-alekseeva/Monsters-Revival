using Abstractions.Basics;

namespace Abstractions.Player
{
    internal interface IPlayerView : IRigidbody, ITransform, IDestroyable, IDamageable, IActionOnTriggerEnter, IHealthBarHolder, ISpawnTransform
    {

    }
}
