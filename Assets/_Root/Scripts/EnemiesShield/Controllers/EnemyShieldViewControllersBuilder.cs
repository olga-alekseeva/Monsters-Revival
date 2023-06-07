using Abstractions.Basics;
using Abstractions.Controllers;
using Abstractions.EnemiesShield;
using Abstractions.Fireball;
using Abstractions.Player;
using Player;

namespace Controllers
{

    internal sealed class EnemyShieldViewControllersBuilder : IEnemyShieldViewControllersBuilder
    {
        private IPlayerInfo _playerInfo;
        private IEnemiesShieldModelSettings _enemiesShieldModelSettings;
        private IUpdateController _updateController;
        private IUpdateableRemoverFactory _updateableRemoverFactory;
        private IFireballInfo _fireballInfo;

        public EnemyShieldViewControllersBuilder(IFireballInfo fireballInfo, IPlayerInfo playerInfo, IEnemiesShieldModelSettings enemiesShieldModelSettings, IUpdateController updateController, IUpdateableRemoverFactory updateableRemoverFactory)
        {
            _fireballInfo = fireballInfo;
            _playerInfo = playerInfo;
            _enemiesShieldModelSettings = enemiesShieldModelSettings;
            _updateController = updateController;
            _updateableRemoverFactory = updateableRemoverFactory;
        }

        public void Build(IEnemiesShieldView enemiesShieldView)
        {

            IUpdateDeltaTime rotateEnemiesShieldController = new RotateEnemiesShieldController(_playerInfo, _fireballInfo, enemiesShieldView, _enemiesShieldModelSettings);
            _updateController.Add(rotateEnemiesShieldController);
            enemiesShieldView.ActionOnDestroy += _updateableRemoverFactory.Create(rotateEnemiesShieldController).Remove;


        }

        public void Build(IEnemiesShieldView[] enemiesShieldViews)
        {
            foreach (IEnemiesShieldView enemiesShieldView in enemiesShieldViews)
            {
                Build(enemiesShieldView);
            }
        }
    }
}
