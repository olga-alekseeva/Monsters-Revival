using Abstractions.Arrow;
using Abstractions.Controllers.Archer;
using Abstractions.Enemy;
using Abstractions.Player;
using UnityEngine;

namespace Controllers.Archer
{
    internal sealed class ArcherAttackController : IArcherAttackController
    {
        private IArcherView _archerView;
        private IPlayerInfo _playerInfo;
        private IArcherModel _archerModel;
        private IArrowEventManager _arrowEventManager;
        private float _timeToFire;

        public ArcherAttackController(IArcherModel archerModel, 
            IArcherView archerView, 
            IPlayerInfo playerInfo, 
            IArrowEventManager arrowEventManager)
        {
            _archerModel = archerModel;
            _archerView = archerView;
            _playerInfo = playerInfo;
            _arrowEventManager = arrowEventManager;
            _timeToFire = archerModel.ArcherModelSettings.ShootingInterval;
        }

        public void Update(float deltatime)
        {
            if (!_playerInfo.IsPreset) return;

            _timeToFire -= deltatime;

            if (_timeToFire <= 0)
            {
                _timeToFire = _archerModel.ArcherModelSettings.ShootingInterval;

                float distanceToPlayer = Vector2.Distance(_archerView.Transform.position, 
                    _playerInfo.PlayerView.Transform.position);
                
                if (distanceToPlayer <= _archerModel.ArcherModelSettings.AttackDistance && 
                    distanceToPlayer > _archerModel.ArcherModelSettings.RetreatDistance)
                {
                    _arrowEventManager.FireStart(
                        _archerView.ArrowStart.transform.position, 
                        _archerView.ArrowStart.transform.rotation, 
                        _archerModel.ArcherModelSettings.ShootingForce);
                }
            }
        }
    }
}
