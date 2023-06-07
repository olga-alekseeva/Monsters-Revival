using Abstractions.Arrow;

namespace Abstractions.Controllers
{
    internal interface IArrowSetDamageControllerBuilder
    {
        void Build(IArrowModel arrowModel, IArrowView arrowView);
    }
}
