using Abstractions.Controllers;
using Abstractions.Fireball;
using Abstractions.Player;
using LaunchCountUI;
using Settings;
using System;
using UnityEngine;

namespace Controllers
{
    internal sealed class LaunchingFireballController : ILaunchingFireballController
    {
        public event Action<int, int> ActionOnFireeBallLaunches = delegate { };

        private const int CAST_RESULTS_COUNT = 32;

        private IFireballInfo _fireballInfo;
        private GameObject _gameObject;
        private IPlayerInfo _playerInfo;
        private RaycastHit2D[] _castResults;
        private int _countTimes = 0;
        private IFireballModelFactory _fireballModelFactory;
        public LaunchingFireballController(GameObject gameObject, 
            IPlayerInfo playerInfo, IFireballInfo fireballInfo, 
            IFireballModelFactory fireballModelFactory)
        {
            _playerInfo = playerInfo;
            _gameObject = gameObject;
            _fireballInfo = fireballInfo;
            _castResults = new RaycastHit2D[CAST_RESULTS_COUNT];
            _fireballModelFactory = fireballModelFactory;
        }
        public void Update(float deltaTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (_countTimes < _fireballInfo.FireballSettings.CountOfLaunches)
                {
                    if (!_playerInfo.IsPreset) return;

                    Vector2 startPosition = _playerInfo.PlayerView.Transform.position;
                    Vector2 spawnPosition = _playerInfo.PlayerView.SpawnTransform.position;
                    Vector2 direction = spawnPosition - startPosition;
                    float distance = direction.magnitude;

                    int castCount = Physics2D.CircleCastNonAlloc(
                        startPosition, _fireballInfo.FireballSettings.Radius, 
                        direction, _castResults, distance);

                    if (castCount > 0)
                    {
                        for (int i = 0; i < castCount; i++)
                        {
                            if (_castResults[i].collider.GetComponentInParent<IPlayerView>() != null) 
                                continue;

                            return;
                        }
                    }
                    GameObject gameObject = GameObject.Instantiate(
                        _gameObject, spawnPosition, Quaternion.identity);

                    IFireballView view = gameObject.GetComponent<IFireballView>();
                    IFireballModel model = 
                        _fireballModelFactory.Create(direction.normalized);
                    _fireballInfo.FireballInstantiated(model, view);
                    _countTimes++;
                    ActionOnFireeBallLaunches.Invoke(
                        _countTimes, _fireballInfo.FireballSettings.CountOfLaunches);
                }
                else
                {
                    return;
                }

            }
        }
    }
}




