using Abstractions.Portal;

namespace Portal
{
    internal sealed class PortalInfo : IPortalInfo
    {
        private IPortalView _portalView;
        private bool _isPreset;

        public IPortalView PortalView => _portalView;
        public bool IsPreset => _isPreset;

        public void Instantiated(IPortalView portalView)
        {
            _portalView = portalView;
            _isPreset = true;
            _portalView.ActionOnDestroy += Destroy;
        }

        public void Destroy()
        {
            _portalView.ActionOnDestroy -= Destroy;
            _isPreset = false;
            _portalView = null;
        }
    }
}
