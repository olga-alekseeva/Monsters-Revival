using UnityEngine;

namespace Abstractions.InputSystem
{
    internal interface IMousePosition
    {
        public Vector3 WorldPosition { get; set; }
        public Vector3 DirectionFromCenterScreen { get; set; }
        public bool IsActive { get; set; }
    }
}
