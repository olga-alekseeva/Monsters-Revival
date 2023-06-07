using Abstractions.Fireball;

namespace Abstractions.Controllers.Fireball
{
    internal interface IFireBallRedirectControllerBuilder
    {
        void Build(IFireballModel model, IFireballView view);
    }

}