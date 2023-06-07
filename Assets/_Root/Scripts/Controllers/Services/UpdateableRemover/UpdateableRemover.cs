using Abstractions.Basics;
using Abstractions.Controllers;

namespace MonstersRevival
{
    internal sealed class UpdateableRemover : IUpdateableRemover
    {
        private IUpdateController _updateController;
        private IUpdateable _updateableController;

        public UpdateableRemover(IUpdateController updateController, IUpdateable updateableController)
        {
            _updateController = updateController;
            _updateableController = updateableController;
        }
        public void Remove()
        {
            _updateController.Remove(_updateableController);
        }
    }
}
