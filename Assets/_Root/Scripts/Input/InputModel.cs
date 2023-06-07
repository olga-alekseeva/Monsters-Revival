using Abstractions.InputSystem;

namespace InputSystem
{
    internal sealed class InputModel : IInputModel
    {
        private IKeyboardAxis _keyboardAxis;
        private IMousePosition _mousePosition;

        public IKeyboardAxis KeyboardAxis => _keyboardAxis;
        public IMousePosition MousePosition => _mousePosition;

        public InputModel(IKeyboardAxis keyboardAxis, IMousePosition mousePosition)
        {
            _keyboardAxis = keyboardAxis;
            _mousePosition = mousePosition;
        }
    }

}
