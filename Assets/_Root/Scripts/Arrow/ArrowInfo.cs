using Abstractions.Arrow;

namespace Arrow
{
    internal sealed class ArrowInfo : IArrowInfo
    {
        private IArrowModel _arrowModel;
        private IArrowView _arrowView;
        private bool _isPreset;
        public bool IsPreset => _isPreset;

        public IArrowView ArrowView => _arrowView;

        public IArrowModel ArrowModel => _arrowModel;


        public void Instantiated(IArrowModel arrowModel, IArrowView arrowView)
        {
            _arrowModel = arrowModel;
            _arrowView = arrowView;
            _isPreset = true;
        }
        public void Destroyed(IArrowModel arrowModel, IArrowView arrowView)
        {
            _arrowModel = null;
            _arrowView = null;
            _isPreset = false;
        }
    }
}
