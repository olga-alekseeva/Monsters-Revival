using UnityEngine;

namespace Abstractions.Controllers
{
    internal interface IEnemyDamageApplyController
    {
        public void OnCollisionEnter2D(Collision2D collision2D);
        public void OnCollisionStay2D(Collision2D collision2D);
    }
}