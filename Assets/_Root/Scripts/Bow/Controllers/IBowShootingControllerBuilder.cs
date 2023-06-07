using Abstractions.Bow;

namespace Abstractions.Controllers
{
    internal interface IBowShootingControllerBuilder
    {
        void Build(IBowInfo bowInfo);
    }
}
