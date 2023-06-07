using Abstractions.Basics;

namespace Abstractions.Controllers
{
    internal interface IUpdateController : IUpdateDeltaTime
    {
        public void Add(IUpdateable updateable);
        public void Remove(IUpdateable updateable);
    }
}