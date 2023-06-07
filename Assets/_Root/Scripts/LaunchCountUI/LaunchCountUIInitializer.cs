using Abstractions.Basics;
using Abstractions.Controllers;
using Abstractions.Fireball;
using Settings;
using UnityEngine;

namespace LaunchCountUI
{
    internal sealed class LaunchCountUIInitializer : ILaunchCountUIInitializer
    {
        private IFireballInfo _fireballInfo;
        private ILaunchingFireballController _launchingFireballController;
        private IUpdateController _updateController;

        public LaunchCountUIInitializer(IFireballInfo fireballInfo, 
            ILaunchingFireballController launchingFireballController, 
            IUpdateController updateController)
        {
            _fireballInfo = fireballInfo;
            _launchingFireballController = launchingFireballController;
            _updateController = updateController;

            Init();
        }

        private void Init()
        {
            ILaunchCountUIModel model = new LaunchCountUIModel();
            model.LaunchesLeft = _fireballInfo.FireballSettings.CountOfLaunches;

            ILaunchCountUILaunchController launchCountUILaunchController = 
                new LaunchCountUILaunchController(model);

            _launchingFireballController.ActionOnFireeBallLaunches += 
                launchCountUILaunchController.UpdateLaunches;

            GameObject prefab = Resources.Load<GameObject>(ResourcePathes.Prefabs.LAUNCH_COUNT_UI);
            GameObject gameObject = GameObject.Instantiate(prefab);
            ILaunchCountUIView view = gameObject.GetComponent<LaunchCountUIView>();

            IUpdate launchCountUIController = new LaunchCountUIController(model, view);
            _updateController.Add(launchCountUIController);
        }
    }
}
