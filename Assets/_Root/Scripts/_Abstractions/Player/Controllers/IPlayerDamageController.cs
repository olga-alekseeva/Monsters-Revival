using Abstractions.Basics;

namespace Abstractions.Controllers
{
    internal interface IPlayerDamageController
    {
        void SetDamage(IDamage damage);
    }
}