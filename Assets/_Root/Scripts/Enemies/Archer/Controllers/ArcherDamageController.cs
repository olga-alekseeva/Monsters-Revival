using Abstractions.Basics;
using Abstractions.Controllers;
using Abstractions.Enemy;
using UnityEngine;

namespace Controllers
{
    internal sealed class ArcherDamageController : IArcherDamageController
    {
        private IArcherModel _archerModel;
        private IArcherEventManager _archerEventManager;
        private IArcherView _archerView;

        public ArcherDamageController(IArcherModel archerModel, IArcherEventManager archerEventManager, IArcherView archerView)
        {
            _archerModel = archerModel;
            _archerEventManager = archerEventManager;
            _archerView = archerView;
        }

        public void SetDamage(IDamage damage)
        {
            _archerModel.Health -= damage.Damage;
            if (_archerModel.Health <= 0)
            {
                _archerModel.Health = 0;
            }
            _archerEventManager.DamageReceived(_archerView, damage);
            if (_archerModel.Health == 0)
            {
                GameObject.Destroy(_archerView.GameObject);
            }
        }
    }
}
