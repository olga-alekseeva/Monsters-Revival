using Abstractions.Basics;
using Abstractions.Controllers;
using Abstractions.Enemy;
using UnityEngine;

namespace Controllers
{
    internal sealed class EnemyDamageController : IEnemyDamageController
    {
        private IEnemyModel _enemyModel;
        private IEnemyEventManager _enemyEventManager;
        private IEnemyView _enemyView;

        public EnemyDamageController(IEnemyEventManager enemyEventManager, IEnemyModel enemyModel, IEnemyView enemyView)
        {
            _enemyEventManager = enemyEventManager;
            _enemyModel = enemyModel;
            _enemyView = enemyView;
        }

        public void SetDamage(IDamage damage)
        {
            _enemyModel.Health -= damage.Damage;
            if (_enemyModel.Health <= 0)
            {
                _enemyModel.Health = 0;
            }
            _enemyEventManager.DamageReceived(_enemyView, damage);

            if (_enemyModel.Health == 0)
            {
                GameObject.Destroy(_enemyView.GameObject);
            }
        }
    }
}