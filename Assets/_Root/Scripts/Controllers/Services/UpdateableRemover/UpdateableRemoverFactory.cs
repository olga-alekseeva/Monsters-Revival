using Abstractions.Basics;
using Abstractions.Controllers;

namespace MonstersRevival
{
    internal sealed class UpdateableRemoverFactory : IUpdateableRemoverFactory
    {
        private IUpdateController _updateController;

        public UpdateableRemoverFactory(IUpdateController updateController)
        {
            _updateController = updateController;
        }

        public IUpdateableRemover Create(IUpdateable updateableController)
        {
            IUpdateableRemover updateableRemover = new UpdateableRemover(_updateController, updateableController);
            return updateableRemover;
        }
    }
}
