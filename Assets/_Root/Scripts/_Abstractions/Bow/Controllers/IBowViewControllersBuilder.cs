using Abstractions.Bow;

namespace Abstractions.Controllers
{
    internal interface IBowViewControllersBuilder
    {
        public void Build(IBowView BowView);
        public void Build(IBowView[] BowViews);
    }
}
