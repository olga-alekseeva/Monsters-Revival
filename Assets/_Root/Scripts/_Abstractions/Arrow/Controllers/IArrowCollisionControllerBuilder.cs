using Abstractions.Arrow;

namespace Abstractions.Controllers
{
    internal interface IArrowCollisionControllerBuilder
    {
        public void Build(IArrowModel model, IArrowView view);
    }
}