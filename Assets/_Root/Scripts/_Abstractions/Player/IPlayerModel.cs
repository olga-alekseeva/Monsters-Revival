using Abstractions.Basics;
using Abstractions.HealthBar;

namespace Abstractions.Player
{
    internal interface IPlayerModel : IHealth, IHealthBarModel
    {
        public IPlayerModelSettings PlayerModelSettings { get; }
    }
}
