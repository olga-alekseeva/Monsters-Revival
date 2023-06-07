using Abstractions.InputSystem;

namespace InputSystem
{
    internal sealed class KeyboardAxis : IKeyboardAxis
    {
        public float Horizontal { get; set; }
        public float Vertical { get; set; }

        public KeyboardAxis()
        {
            Horizontal = 0;
            Vertical = 0;
        }
    }

}
