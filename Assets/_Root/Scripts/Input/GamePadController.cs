using Abstractions.Controllers.InputSystem;
using Abstractions.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;
namespace InputSystem
{
    internal sealed class GamePadController : IGamePadController
    {
        private IInputModel _inputModel;

        public GamePadController(IInputModel inputModel)
        {
            _inputModel = inputModel;
        }

        public void Update()
        {
            if (Gamepad.current == null)
            {
                Debug.LogError("GamePad not detected");
                return;
            }

            _inputModel.KeyboardAxis.Horizontal = Gamepad.current.leftStick.x.ReadValue();
            _inputModel.KeyboardAxis.Vertical = Gamepad.current.leftStick.y.ReadValue();

            float rightStickValueX = Gamepad.current.rightStick.x.ReadValue();
            float rightStickValueY = Gamepad.current.rightStick.y.ReadValue();
            float viewPortPositionX = 0.5f + (rightStickValueX / 2f);
            float viewPortPositionY = 0.5f + (rightStickValueY / 2f);
            Vector2 viewPortPosition = new Vector2(viewPortPositionX, viewPortPositionY);

            _inputModel.MousePosition.WorldPosition = Camera.main.ViewportToWorldPoint(viewPortPosition);
            _inputModel.MousePosition.DirectionFromCenterScreen = new Vector3(rightStickValueX, rightStickValueY, 0);
            if (rightStickValueX != 0 || rightStickValueY != 0)
            {
                _inputModel.MousePosition.IsActive = true;
            }
            else
            {
                _inputModel.MousePosition.IsActive = false;
            }
            

        }
    }
}
