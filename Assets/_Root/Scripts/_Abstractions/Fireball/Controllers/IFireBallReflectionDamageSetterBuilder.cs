using Abstractions.Fireball;

namespace Abstractions.Controllers
{
    internal interface IFireBallReflectionDamageSetterBuilder
    {
        void Build(IFireballModel fireballModel, IFireballView fireballView);
    }
}