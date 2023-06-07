using Abstractions.Controllers;
using Abstractions.Fireball;

namespace Controllers
{
    internal sealed class FireballDamageApplyControllerBuilder : IFireballDamageApplyControllerBuilder
    {
        public void Build(IFireballModel fireballModel, IFireballView fireballView)
        {
            IFireballDamageApplyController controller = new FireballDamageApplyController(fireballModel);
            fireballView.ActionOnTriggerEnter += controller.OnTriggerEnter;
        }
    }
}