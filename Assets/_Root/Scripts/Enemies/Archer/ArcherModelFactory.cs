using Abstractions.Enemy;

namespace Enemy
{
    internal sealed class ArcherModelFactory : IArcherModelFactory
    {
        private IArcherModelSettings _archerModelSettings;

        public ArcherModelFactory(IArcherModelSettings archerModelSettings)
        {
            _archerModelSettings = archerModelSettings;
        }
        public IArcherModel Create()
        {
            IArcherModel archerModel = new ArcherModel(_archerModelSettings);
            return archerModel;
        }
    }
}
