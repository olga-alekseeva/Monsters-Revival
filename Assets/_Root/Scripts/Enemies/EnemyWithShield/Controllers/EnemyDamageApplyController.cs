using Abstractions.Basics;
using Abstractions.Controllers;
using Abstractions.Enemy;
using Settings;
using System;
using UnityEngine;

namespace Controllers
{
    internal sealed class EnemyDamageApplyController : IEnemyDamageApplyController
    {
        private IEnemyModel _enemyModel;
        private DateTime _lastDamageTime;

        public EnemyDamageApplyController(IEnemyModel enemyModel)
        {
            _enemyModel = enemyModel;
            _lastDamageTime = DateTime.UtcNow;
        }

        private void ApplyDamage(Collision2D collision2D)
        {
            DateTime currentTime = DateTime.UtcNow;
            TimeSpan interval = currentTime - _lastDamageTime;
            if (interval < TimeSpan.FromSeconds(_enemyModel.EnemyModelSettings.DamageInterval)) return;

            if (!collision2D.collider.CompareTag(TagNames.PLAYER)) return;

            IDamageable damageable = collision2D.transform.GetComponentInParent<IDamageable>();
            if (damageable == null) return;

            damageable.SetDamage(_enemyModel.EnemyModelSettings);
            _lastDamageTime = DateTime.UtcNow;
        }
        public void OnCollisionEnter2D(Collision2D collision2D)
        {
            ApplyDamage(collision2D);
        }

        public void OnCollisionStay2D(Collision2D collision2D)
        {
            ApplyDamage(collision2D);
        }
    }
}
