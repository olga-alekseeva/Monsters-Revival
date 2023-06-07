using Abstractions.Basics;
using Abstractions.Controllers;
using Abstractions.Enemy;
using Abstractions.Player;
using Player;

namespace Controllers
{
    internal sealed class EnemyMoveControllerBuilder : IEnemyMoveControllerBuilder
    {
        private IEnemyModelSettings _enemyModelSettings;
        private IPlayerInfo _playerInfo;
        private IUpdateController _updateController;
        private IUpdateableRemoverFactory _updateableRemoverFactory;
        private ITargetPatrolFinder _targetPatrolFinder;

        public EnemyMoveControllerBuilder(IEnemyModelSettings enemyModelSettings, 
            IPlayerInfo playerInfo, IUpdateController updateController, 
            IUpdateableRemoverFactory updateableRemoverFactory, 
            ITargetPatrolFinder targetPatrolFinder)
        {
            _enemyModelSettings = enemyModelSettings;
            _playerInfo = playerInfo;
            _updateController = updateController;
            _updateableRemoverFactory = updateableRemoverFactory;
            _targetPatrolFinder = targetPatrolFinder;
        }

        public void Build(IEnemyModel enemyModel, IEnemyView enemyView)
        {
            IUpdateDeltaTime enemyMoveController = new EnemyMoveController(
                enemyModel, enemyView, _playerInfo, _targetPatrolFinder);
            _updateController.Add(enemyMoveController);
            enemyView.ActionOnDestroy += _updateableRemoverFactory.Create(
                enemyMoveController).Remove;
        }
    }
}
