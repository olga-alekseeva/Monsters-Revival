using Abstractions.Basics;

namespace Abstractions.Controllers
{
    internal interface IUpdateableRemoverFactory
    {
        public IUpdateableRemover Create(IUpdateable updateableController);
    }
}