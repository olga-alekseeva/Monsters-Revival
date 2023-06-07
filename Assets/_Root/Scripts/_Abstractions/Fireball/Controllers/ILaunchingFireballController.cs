using Abstractions.Basics;
using System;

namespace Abstractions.Controllers
{
    internal interface ILaunchingFireballController : IUpdateDeltaTime
    {
        public event Action<int, int> ActionOnFireeBallLaunches;
    }
}
