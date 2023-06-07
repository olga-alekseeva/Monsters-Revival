using Abstractions.Bow;

namespace Bow
{
    internal sealed class BowInfo : IBowInfo
    {
        private IBowView _bowView;
        private IBowModel _bowModel;
        private bool _isPreset;

        public bool IsPreset => _isPreset;

        public IBowModel BowModel => _bowModel;

        public IBowView BowView => _bowView;


        public void Instantiated(IBowModel bowModel, IBowView bowView)
        {
            _bowModel = bowModel;
            _bowView = bowView;
            _isPreset = true;
        }
        public void Destroyed(IBowModel model, IBowView bowView)
        {
            _bowModel = null;
            _bowView = null;
            _isPreset = false;
        }

    }
}
