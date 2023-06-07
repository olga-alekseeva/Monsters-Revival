using Abstractions.Fireball;

namespace Abstractions.Controllers
{
    internal interface IFireballDamageApplyControllerBuilder
    {
        void Build(IFireballModel fireballModel, IFireballView fireballView);
    }
}