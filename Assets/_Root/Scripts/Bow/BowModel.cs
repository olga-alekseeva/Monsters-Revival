using Abstractions.Bow;

namespace Bow
{
    internal sealed class BowModel : IBowModel
    {
        private IBowModelSettings _bowModelsettings;
        public IBowModelSettings BowModelSettings => _bowModelsettings;
        public BowModel(IBowModelSettings bowModelsettings)
        {
            _bowModelsettings = bowModelsettings;
        }
    }
}
