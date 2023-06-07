using UnityEngine;

namespace Abstractions.Controllers
{
    internal interface IPlayerExitPortalController
    {
        void OnTriggerEnter2D(Collider2D collision);
    }
}