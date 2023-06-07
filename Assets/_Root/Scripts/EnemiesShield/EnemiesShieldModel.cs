using Abstractions.EnemiesShield;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemiesShield
{
    internal sealed class EnemiesShieldModel : IEnemiesShieldModel
    {
        private IEnemiesShieldModelSettings _enemiesShieldModelSettings;
        public IEnemiesShieldModelSettings ModelSettings => _enemiesShieldModelSettings;

        public EnemiesShieldModel(IEnemiesShieldModelSettings enemiesShieldModelSettings)
        {
            _enemiesShieldModelSettings = enemiesShieldModelSettings;
        }
    }
}
