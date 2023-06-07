using Abstractions.Arrow;

namespace Abstractions.Controllers
{
    internal interface IArrowMoveControllerBuilder
    {
        void Build(IArrowModel arrowModel, IArrowView arrowView);
    }
}
