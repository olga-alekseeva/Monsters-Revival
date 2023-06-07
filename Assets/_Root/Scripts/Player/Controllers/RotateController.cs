using Abstractions.Basics;
using Abstractions.Controllers;
using Abstractions.InputSystem;
using InputSystem;
using UnityEngine;

namespace Controllers
{
    internal sealed class RotateController : IRotateController
    {
        private const float Z_ANGLE_OFFSET = 90;
        private ITransform _rotateObject;
        private IMousePosition _mousePosition;

        public RotateController(ITransform rotateObject, IMousePosition mousePosition)
        {
            _rotateObject = rotateObject;
            _mousePosition = mousePosition;
        }

        public void Update()
        {
            if (!_mousePosition.IsActive) return;
            Vector2 targetPosition = _mousePosition.WorldPosition;
            Vector3 eulerAngles = _rotateObject.Transform.rotation.eulerAngles;
            Vector3 direction = _mousePosition.DirectionFromCenterScreen;
            float eulerAngleZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - Z_ANGLE_OFFSET;
            _rotateObject.Transform.rotation = Quaternion.Euler(eulerAngles.x, eulerAngles.y, eulerAngleZ);
        }
    }
}
