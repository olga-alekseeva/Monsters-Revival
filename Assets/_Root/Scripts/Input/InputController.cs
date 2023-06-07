using Abstractions.Controllers.InputSystem;
using Abstractions.InputSystem;
using UnityEngine;

namespace InputSystem
{
    internal sealed class InputController : IInputController
    {
        private IKeyBoardController _keyBoardController;
        private IGamePadController _gamePadController;

        private bool _isKeyBoardCurrent;

        public InputController(IKeyBoardController keyBoardController, IGamePadController gamePadController)
        {
            _keyBoardController = keyBoardController;
            _gamePadController = gamePadController;
            _isKeyBoardCurrent = true;
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                _isKeyBoardCurrent = !_isKeyBoardCurrent;
            }

            if (_isKeyBoardCurrent)
            {
                _keyBoardController.Update();
            }
            else
            {
                _gamePadController.Update();
            }
        }
    }
}
