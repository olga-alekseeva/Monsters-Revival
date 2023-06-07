using Abstractions.Enemy;


namespace Abstractions.Controllers
{
    internal interface IArcherMoveControllerBuilder
    {
        public void Build(IArcherModel archerModel, IArcherView archerView);
    }
}
