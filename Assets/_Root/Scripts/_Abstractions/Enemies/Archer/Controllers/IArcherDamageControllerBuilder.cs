 using Abstractions.Enemy;


namespace Abstractions.Controllers
{
    internal interface IArcherDamageControllerBuilder 
    {
        void Build(IArcherModel archerModel, IArcherView archerView);
    }
}
