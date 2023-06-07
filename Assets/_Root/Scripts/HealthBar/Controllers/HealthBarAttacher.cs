using Abstractions.Basics;
using Abstractions.Controllers;
using Abstractions.HealthBar;
using UnityEngine;

namespace Controllers
{
    internal sealed class HealthBarAttacher : IHealthBarAttacher
    {
        private GameObject _healthBarPrefab;
        private IHealthBarControllerBuilder _healthBarControllerBuilder;

        public HealthBarAttacher(GameObject healthBarPrefab, IHealthBarControllerBuilder healthBarControllerBuilder)
        {
            _healthBarPrefab = healthBarPrefab;
            _healthBarControllerBuilder = healthBarControllerBuilder;
        }

        public void Attach(IHealthBarModel healthBarModel, IHealthBarHolder healthBarHolder)
        {
            GameObject healthBar = GameObject.Instantiate(_healthBarPrefab, healthBarHolder.HealthBarRoot);
            IHealthBarView healthBarview = healthBar.GetComponentInChildren<IHealthBarView>();
            healthBarview.Canvas.worldCamera = Camera.main;
            _healthBarControllerBuilder.Build(healthBarModel, healthBarview);
        }
    }
}
