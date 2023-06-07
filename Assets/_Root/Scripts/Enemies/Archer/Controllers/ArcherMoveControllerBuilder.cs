using Abstractions.Basics;
using Abstractions.Controllers;
using Abstractions.Enemy;
using Abstractions.Player;
using Controllers;

namespace Controller
{
    internal sealed class ArcherMoveControllerBuilder : IArcherMoveControllerBuilder
    {
        private IArcherModelSettings _archerModelSettings;
        private IArcherModel _archerModel;
        private IArcherEventManager _archerEventManager;
        private IArcherView _archerView;
        private IPlayerInfo _playerInfo;
        private IUpdateController _updateController;
        private IUpdateableRemoverFactory _updateableRemoverFactory;
        private ITargetPatrolFinder _targetPatrolFinder;

        public ArcherMoveControllerBuilder(IArcherEventManager archerEventManager, IArcherModelSettings archerModelSettings, 
        IPlayerInfo playerInfo, IUpdateController updateController, IUpdateableRemoverFactory updateableRemoverFactory, ITargetPatrolFinder targetPatrolFinder)
        {
            _archerEventManager = archerEventManager;
            _archerModelSettings = archerModelSettings;
            _playerInfo = playerInfo;
            _updateController = updateController;
            _updateableRemoverFactory = updateableRemoverFactory;
            _targetPatrolFinder = targetPatrolFinder;
        }
        public void Build(IArcherModel archerModel, IArcherView archerView)
        {
            IUpdateDeltaTime archerMoveController = new ArcherMoveController(archerModel, archerView, _playerInfo, _targetPatrolFinder);
            _updateController.Add(archerMoveController);
            archerView.ActionOnDestroy += _updateableRemoverFactory.Create(archerMoveController).Remove;
        }
    }
}
