using Abstractions.Basics;
using Abstractions.Controllers;
using Abstractions.Shield;
using System;
using UnityEngine;

namespace Controllers
{
    internal sealed class FireBallReflectionDamageSetter 
        : IFireBallReflectionDamageSetter
    {
        public event Action<Vector3> ActionHitEffect = delegate { };

        private IDamage _damage;
        private ISetDamage _setDamage;
        private IDamageIncrementStep _damageIncrementStep;

        public FireBallReflectionDamageSetter(IDamage damage, 
            ISetDamage setDamage, IDamageIncrementStep damageIncrementStep)
        {
            _damage = damage;
            _setDamage = setDamage;
            _damageIncrementStep = damageIncrementStep;
        }

        private bool IsPlayerCollision(Collision2D collision)
        {
            IShieldView shield = 
                collision.collider.GetComponentInParent<IShieldView>();

            return shield != null;
        }
        public void ActionOnCollisionEnter(Collision2D collision)
        {
            ActionHitEffect.Invoke(collision.GetContact(0).point);
            if (!IsPlayerCollision(collision)) return;
            IncrementDamage();
        }

        private void IncrementDamage()
        {
            _setDamage.SetDamage(_damage.Damage + _damageIncrementStep.DamageIncrementStep);
        }
    }
}
