using Abstractions.Basics;
using Abstractions.Controllers;
using Abstractions.Player;
using UnityEngine;

namespace Controllers
{
    internal sealed class MainCameraController : IMainCameraController
    {
        private IMainCameraSettings _mainCameraSettings;
        private IPlayerInfo _playerInfo;

        public MainCameraController(IMainCameraSettings mainCameraSettings, IPlayerInfo _layerInfo)
        {
            _mainCameraSettings = mainCameraSettings;
            _playerInfo = _layerInfo;
        }

        public void Update(float deltaTime)
        {
            if (!_playerInfo.IsPreset) return;
            Vector3 currentPosition = Camera.main.transform.position;
            float z = currentPosition.z;
            Vector3 targetPosition = _playerInfo.PlayerView.Transform.position;
            Vector3 nextPosition = Vector3.Lerp(currentPosition, targetPosition, _mainCameraSettings.Speed * deltaTime);
            nextPosition.z = z;
            Camera.main.transform.position = nextPosition;
        }
    }
}
