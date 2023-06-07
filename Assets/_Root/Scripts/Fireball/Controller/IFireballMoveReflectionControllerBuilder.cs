using Abstractions.Fireball;

namespace Abstractions.Controllers.Fireball
{
    internal interface IFireballMoveReflectionControllerBuilder
    {
        void Build(IFireballModel model, IFireballView view);
    }

}