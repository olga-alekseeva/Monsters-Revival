using Abstractions.Basics;
using Abstractions.Controllers;
using Abstractions.Player;
using Abstractions.SimpleEnemy;

namespace Controllers
{
    internal sealed class SimpleEnemyMoveControllerBuilder : ISimpleEnemyMoveControllerBuilder
    {
        private ISimpleEnemyModelSettings _simpleEnemyModelSettings;
        private ISimpleEnemyEventManager _eventManager;
        private ISimpleEnemyView _simpleEnemyView;
        private IPlayerInfo _playerInfo;
        private IUpdateController _updateController;
        private IUpdateableRemoverFactory _updateableRemoverFactory;
        private ITargetPatrolFinder _targetPatrolFinder;

        public SimpleEnemyMoveControllerBuilder
            (ISimpleEnemyModelSettings simpleEnemyModelSettings,
            ISimpleEnemyEventManager eventManager,IPlayerInfo playerInfo, 
            IUpdateableRemoverFactory updateableRemoverFactory, 
            ITargetPatrolFinder targetPatrolFinder, IUpdateController updateController)
        {
            _simpleEnemyModelSettings = simpleEnemyModelSettings;
            _eventManager = eventManager;
            _playerInfo = playerInfo;
            _updateableRemoverFactory = updateableRemoverFactory;
            _targetPatrolFinder = targetPatrolFinder;
            _updateController = updateController;

        }

        public void Build(ISimpleEnemyModel simpleEnemyModel, ISimpleEnemyView simpleEnemyView)
        {
            IUpdateDeltaTime simpleEnemyMoveController =
                new SimpleEnemyMoveController(simpleEnemyModel,
                simpleEnemyView, _playerInfo, _targetPatrolFinder);
            _updateController.Add(simpleEnemyMoveController);
            simpleEnemyView.ActionOnDestroy += _updateableRemoverFactory.Create(simpleEnemyMoveController).Remove;
        }
    }
}
