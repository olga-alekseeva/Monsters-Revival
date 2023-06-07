using Abstractions.Enemy;

namespace Abstractions.Controllers.Archer
{
    internal interface IArcherAttackControllerBuider
    {
        void Build(IArcherModel archerModel, IArcherView archerView);
    }
}