using Abstractions.Controllers;
using Abstractions.Portal;

namespace Controllers
{
    internal sealed class PortalShowController : IPortalShowController
    {
        private IPortalInfo _portalInfo;

        public PortalShowController(IPortalInfo portalInfo)
        {
            _portalInfo = portalInfo;
        }

        public void ShowPortal()
        {
            if (!_portalInfo.IsPreset) return;
            _portalInfo.PortalView.GameObject.SetActive(true);
        }
    }
}
