using Abstractions.Basics;
using Abstractions.Controllers;
using Abstractions.SimpleEnemy;
using UnityEngine;

namespace Controllers
{
    internal sealed class SimpleEnemyDamageController : ISimpleEnemyDamageController
    {
        private ISimpleEnemyModel _simpleEnemyModel;
        private ISimpleEnemyEventManager _simpleEnemyEventManager;
        private ISimpleEnemyView _simpleEnemyView;

        public SimpleEnemyDamageController(ISimpleEnemyModel simpleEnemyModel, ISimpleEnemyEventManager eventManager, ISimpleEnemyView simpleEnemyView)
        {
            _simpleEnemyModel = simpleEnemyModel;
            _simpleEnemyEventManager = eventManager;
            _simpleEnemyView = simpleEnemyView;
        }

        public void SetDamage(IDamage damage)
        {
            _simpleEnemyModel.Health -= damage.Damage;
            if(_simpleEnemyModel.Health <= 0)
            {
                _simpleEnemyModel.Health = 0;
            }
            _simpleEnemyEventManager.DamageReceived(_simpleEnemyView, damage);
            if(_simpleEnemyModel.Health == 0)
            {
                GameObject.Destroy(_simpleEnemyView.GameObject);
            }

        }
    }
}
