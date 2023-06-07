namespace LaunchCountUI
{
    internal sealed class LaunchCountUILaunchController : ILaunchCountUILaunchController
    {
        private ILaunchCountUIModel _model;

        public LaunchCountUILaunchController(ILaunchCountUIModel model)
        {
            _model = model;
        }

        public void UpdateLaunches(int countLaunches, int totalLaunches)
        {
            _model.LaunchesLeft = totalLaunches - countLaunches;
        }
    }
}
