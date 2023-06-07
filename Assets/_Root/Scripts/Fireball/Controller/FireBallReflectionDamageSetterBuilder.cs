using Abstractions.Controllers;
using Abstractions.Effects;
using Abstractions.Fireball;

namespace Controllers
{
    internal sealed class FireBallReflectionDamageSetterBuilder : IFireBallReflectionDamageSetterBuilder
    {
        private IEffectEventManager _effectEventManager;
        private IFireballSettings _fireballSettings;

        public FireBallReflectionDamageSetterBuilder(
            IEffectEventManager effectEventManager, 
            IFireballSettings fireballSettings)
        {
            _effectEventManager = effectEventManager;
            _fireballSettings = fireballSettings;
        }

        public void Build(IFireballModel fireballModel, IFireballView fireballView)
        {
            IFireBallReflectionDamageSetter controller = 
                new FireBallReflectionDamageSetter(
                    fireballModel, fireballModel, _fireballSettings);

            fireballView.ActionOnCollisionEnter += controller.ActionOnCollisionEnter;
            controller.ActionHitEffect += _effectEventManager.StartHitEffect;
        }
    }
}
