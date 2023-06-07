using Abstractions.HealthBar;
using System;
using TMPro;
using UnityEngine;

namespace HealthBar
{
    internal sealed class HealthBarView : MonoBehaviour, IHealthBarView
    {
        [SerializeField] private Transform _barScale;
        [SerializeField] private SpriteRenderer _barSpriteRenderer;
        [SerializeField] private Canvas _canvas;
        [SerializeField] private TextMeshProUGUI _textMeshProUGUI;

        public event Action ActionOnDestroy = delegate { };

        public Transform BarScale => _barScale;
        public SpriteRenderer BarSpriteRenderer => _barSpriteRenderer;
        public Canvas Canvas => _canvas;
        public TextMeshProUGUI TextMeshProUGUI => _textMeshProUGUI;

        private void OnDestroy()
        {
            ActionOnDestroy.Invoke();
        }
    }
}
