using Abstractions.InputSystem;
using UnityEngine;

namespace InputSystem
{
    internal sealed class MousePosition : IMousePosition
    {
        public Vector3 WorldPosition { get; set; }
        public bool IsActive { get; set; }
        public Vector3 DirectionFromCenterScreen { get; set; }

        public MousePosition()
        {
            WorldPosition = Vector3.zero;
            IsActive = false;
            DirectionFromCenterScreen = Vector3.zero;
        }
    }

}
