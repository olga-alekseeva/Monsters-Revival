using Abstractions.Basics;

namespace LaunchCountUI
{
    internal sealed class LaunchCountUIController : IUpdate
    {
        private ILaunchCountUIModel _model;
        private ILaunchCountUIView _view;
        private int _displayedValue = -1;

        public LaunchCountUIController(ILaunchCountUIModel model, ILaunchCountUIView view)
        {
            _model = model;
            _view = view;
        }

        public void Update()
        {
            if (_model.LaunchesLeft != _displayedValue)
            {
                _displayedValue = _model.LaunchesLeft;
                _view.Text.text = _displayedValue.ToString();
            }
        }
    }
}
