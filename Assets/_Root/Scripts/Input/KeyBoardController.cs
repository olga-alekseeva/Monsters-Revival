using Abstractions.Controllers.InputSystem;
using Abstractions.InputSystem;
using UnityEngine;
namespace InputSystem
{
    internal sealed class KeyBoardController : IKeyBoardController
    {
        private IInputModel _inputModel;

        public KeyBoardController(IInputModel inputModel)
        {
            _inputModel = inputModel;
        }

        public void Update()
        {
            _inputModel.KeyboardAxis.Horizontal = Input.GetAxis(AxisNames.HORIZONTAL);
            _inputModel.KeyboardAxis.Vertical = Input.GetAxis(AxisNames.VERTICAL);
            Vector3 mousePosition = Input.mousePosition;
            _inputModel.MousePosition.WorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector3 centerScreen = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2, 0);
            _inputModel.MousePosition.DirectionFromCenterScreen = mousePosition - centerScreen;
            _inputModel.MousePosition.IsActive = true;
        }
    }
}
