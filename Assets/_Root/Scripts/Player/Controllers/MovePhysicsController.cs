using Abstractions.Basics;
using Abstractions.Controllers;
using Abstractions.InputSystem;
using Settings;
using UnityEngine;

namespace Controllers
{
    internal sealed class MovePhysicsController : IMovePhysicsController
    {
        private IRigidbody _moveObject;
        private ISpeed _settings;
        private IInputModel _inputModel;

        public MovePhysicsController(IRigidbody moveObject, IInputModel inputModel, ISpeed settings)
        {
            _moveObject = moveObject;
            _settings = settings;
            _inputModel = inputModel;
        }

        public void Update(float deltaTime)
        {
            float moveX = _inputModel.KeyboardAxis.Horizontal * _settings.Speed * deltaTime;
            float moveY = _inputModel.KeyboardAxis.Vertical * _settings.Speed * deltaTime;
            Vector2 forward = _moveObject.Rigidbody.transform.up * moveY;
            Vector2 right = _moveObject.Rigidbody.transform.right * moveX;
            Vector2 targetPosition = _moveObject.Rigidbody.position + forward + right;
            _moveObject.Rigidbody.MovePosition(targetPosition);
        }
    }
}
