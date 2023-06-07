using Abstractions.Basics;
using Abstractions.Controllers;
using Abstractions.InputSystem;
using UnityEngine;

namespace Controllers
{
    internal sealed class RotateSpeedController : IRotateSpeedController
    {
        private const float Z_ANGLE_OFFSET = 90;
        private ITransform _rotateObject;
        private IMousePosition _mousePosition;
        private IRotateSpeed _rotateSpeed;

        public RotateSpeedController(ITransform rotateObject, IMousePosition mousePosition, IRotateSpeed rotateSpeed)
        {
            _rotateObject = rotateObject;
            _mousePosition = mousePosition;
            _rotateSpeed = rotateSpeed;
        }

        public void Update(float deltaTime)
        {
            if (!_mousePosition.IsActive) return;
            Vector2 targetPosition = _mousePosition.WorldPosition;
            Vector3 eulerAngles = _rotateObject.Transform.rotation.eulerAngles;
            Vector3 direction = _mousePosition.DirectionFromCenterScreen;
            float eulerAngleZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - Z_ANGLE_OFFSET;
            Quaternion currentRotation = _rotateObject.Transform.rotation;
            Quaternion targetRotation = Quaternion.Euler(eulerAngles.x, eulerAngles.y, eulerAngleZ);

            _rotateObject.Transform.rotation = Quaternion.RotateTowards(currentRotation, targetRotation,
                deltaTime * _rotateSpeed.RotateSpeed);
        }
    }
}
