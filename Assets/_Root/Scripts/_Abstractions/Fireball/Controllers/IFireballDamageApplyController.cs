using UnityEngine;

namespace Abstractions.Controllers
{
    internal interface IFireballDamageApplyController
    {
        void OnTriggerEnter(Collider2D collider2D);
    }
}