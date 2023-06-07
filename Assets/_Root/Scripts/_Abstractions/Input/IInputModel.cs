namespace Abstractions.InputSystem
{
    internal interface IInputModel
    {
        public IKeyboardAxis KeyboardAxis { get; }
        public IMousePosition MousePosition { get; }
        
    }
}
