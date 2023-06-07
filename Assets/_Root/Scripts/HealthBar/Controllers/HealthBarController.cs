using Abstractions.Controllers;
using Abstractions.HealthBar;
using UnityEngine;

namespace Controllers
{
    internal sealed class HealthBarController : IHealthBarController
    {
        private const int FULL_PERCENT = 100;

        private IHealthBarModel _healthBarModel;
        private IHealthBarView _healthBarView;

        private int _displayedHealth;

        public HealthBarController(IHealthBarModel healthBarModel, IHealthBarView healthBarView)
        {
            _healthBarModel = healthBarModel;
            _healthBarView = healthBarView;
            RefreshDisplayedHealthText(FULL_PERCENT);
        }

        private void RefreshDisplayedHealthText(int displayHealthPrecent)
        {
            string text = displayHealthPrecent.ToString();
            _healthBarView.TextMeshProUGUI.text = text;
            _displayedHealth = displayHealthPrecent;
        }

        public void Update()
        {
            float percent = _healthBarModel.CurrentHealth / _healthBarModel.MaxHealth;
            _healthBarView.BarScale.localScale = new Vector3(percent, 1, 1);

            int displayHealthPrecent = Mathf.RoundToInt(percent * FULL_PERCENT);
            if (displayHealthPrecent != _displayedHealth) RefreshDisplayedHealthText(displayHealthPrecent);

            Color displayeColor = Color.Lerp(_healthBarModel.MinColor, _healthBarModel.MaxColor, percent);
            _healthBarView.BarSpriteRenderer.color = displayeColor;
            _healthBarView.TextMeshProUGUI.color = displayeColor;
        }
    }
}
