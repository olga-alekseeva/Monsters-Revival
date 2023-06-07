using UnityEngine;

namespace Abstractions.Basics
{
    internal interface IHealthBarHolder
    {
        public Transform HealthBarRoot { get; }
    }
}