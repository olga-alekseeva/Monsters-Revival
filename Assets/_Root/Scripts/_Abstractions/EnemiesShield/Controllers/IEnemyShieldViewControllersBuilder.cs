using Abstractions.EnemiesShield;

namespace Abstractions.Controllers
{
    internal interface IEnemyShieldViewControllersBuilder
    {
        public void Build(IEnemiesShieldView enemiesShieldView);
        public void Build(IEnemiesShieldView[] enemiesShieldViews);
    }
}