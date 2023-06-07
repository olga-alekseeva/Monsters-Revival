using Abstractions.Arrow;
using Abstractions.Bow;
using Abstractions.Controllers;

namespace Controllers
{
    internal sealed class ArrowSetDamageControllerBuilder : IArrowSetDamageControllerBuilder
    {
        private IBowModelSettings _bowModelSettings;
        public void Build(IArrowModel arrowModel, IArrowView arrowView)
        {
            
        }
    }
}
