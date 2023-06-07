using Abstractions.Basics;
using Abstractions.HealthBar;

namespace Abstractions.Controllers
{
    internal interface IHealthBarAttacher
    {
        void Attach(IHealthBarModel healthBarModel, IHealthBarHolder healthBarHolder);
    }
}