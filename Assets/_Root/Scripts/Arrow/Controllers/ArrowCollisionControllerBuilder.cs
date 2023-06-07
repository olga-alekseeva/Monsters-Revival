using Abstractions.Arrow;
using Abstractions.Controllers;

namespace Controllers.Arrow
{
    internal sealed class ArrowCollisionControllerBuilder : IArrowCollisionControllerBuilder
    {
        public void Build(IArrowModel model, IArrowView view)
        {
            new ArrowCollisionController(model, view);
        }
    }
}
