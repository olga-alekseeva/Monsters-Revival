using Abstractions.Basics;

namespace Abstractions.Controllers
{
    internal interface IEnemyDamageController
    {
        void SetDamage(IDamage damage);
    }
}