using Abstractions.Arrow;
using Abstractions.Basics;
using Abstractions.Controllers;
using Abstractions.Controllers.Archer;
using Abstractions.Enemy;
using Abstractions.Player;

namespace Controllers.Archer
{
    internal sealed class ArcherAttackControllerBuider : IArcherAttackControllerBuider
    {
        private IPlayerInfo _playerInfo;
        private IArrowEventManager _arrowEventManager;
        private IUpdateableRemoverFactory _updateableRemoverFactory;
        private IUpdateController _updateController;

        public ArcherAttackControllerBuider(IPlayerInfo playerInfo, 
            IArrowEventManager arrowEventManager, 
            IUpdateController updateController, 
            IUpdateableRemoverFactory updateableRemoverFactory)
        {
            _playerInfo = playerInfo;
            _arrowEventManager = arrowEventManager;
            _updateableRemoverFactory = updateableRemoverFactory;
            _updateController = updateController;
        }

        public void Build(IArcherModel archerModel, IArcherView archerView)
        {
            IUpdateDeltaTime controller = new ArcherAttackController(
                archerModel, archerView, _playerInfo, _arrowEventManager);

            _updateController.Add(controller);
            
            archerView.ActionOnDestroy += 
                _updateableRemoverFactory.Create(controller).Remove;
        }
    }
}
