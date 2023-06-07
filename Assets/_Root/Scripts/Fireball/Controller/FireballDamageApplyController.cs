using Abstractions.Basics;
using Abstractions.Controllers;
using Abstractions.Fireball;
using UnityEngine;

namespace Controllers
{
    internal sealed class FireballDamageApplyController : IFireballDamageApplyController
    {
        private IFireballModel _fireballModel;

        public FireballDamageApplyController(IFireballModel fireballModel)
        {
            _fireballModel = fireballModel;
        }
        public void OnTriggerEnter(Collider2D collider2D)
        {
            IDamageable damageable = collider2D.GetComponentInParent<IDamageable>();
            if (damageable == null) return;
            damageable.SetDamage(_fireballModel);
        }
    }
}