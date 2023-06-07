using Abstractions.Basics;
using TMPro;
using UnityEngine;

namespace Abstractions.HealthBar
{
    internal interface IHealthBarView : IDestroyable
    {
        Transform BarScale { get; }
        SpriteRenderer BarSpriteRenderer { get; }
        Canvas Canvas { get; }
        TextMeshProUGUI TextMeshProUGUI { get; }
    }
}