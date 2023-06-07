namespace Abstractions.Portal
{
    internal interface IPortalInfo
    {
        bool IsPreset { get; }
        IPortalView PortalView { get; }

        void Instantiated(IPortalView portalView);
    }
}