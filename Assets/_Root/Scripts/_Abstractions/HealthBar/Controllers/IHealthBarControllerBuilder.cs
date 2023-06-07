using Abstractions.HealthBar;

namespace Abstractions.Controllers
{
    internal interface IHealthBarControllerBuilder
    {
        void Build(IHealthBarModel healthBarModel, IHealthBarView healthBarView);
    }
}