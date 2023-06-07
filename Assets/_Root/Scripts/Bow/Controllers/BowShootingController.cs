using Abstractions.Arrow;
using Abstractions.Basics;
using Abstractions.Bow;
using Abstractions.Controllers;
using Abstractions.Player;
using Controller;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers.Bow
{
    internal sealed class BowShootingController : IBowShootingController
    {
        private int _index;
        private IWaitTime _waitTime;
        private IArrowInfo _arrowInfo;
        private IPlayerInfo _playerInfo;
        private IBowInfo _bowInfo;
        private IArrowViewFactory _arrowViewFactory;
        private IArrowModelFactory _arrowModelFactory;

        public BowShootingController(IWaitTime waitTime, IArrowInfo arrowInfo, IBowInfo bowInfo, IPlayerInfo playerInfo)
        {
            _waitTime = waitTime;
            _arrowInfo = arrowInfo;
            _bowInfo = bowInfo;
            _playerInfo = playerInfo;
        }

        public void Update(float deltaTime)
        {
            if (!_playerInfo.IsPreset) return;
            if (_waitTime.WaitTime > 0)
            {
                
                _waitTime.WaitTime -= Time.deltaTime;
            }
            else
            {
                _waitTime.WaitTime = 0;
             
                _index++;
              
                {
                    _index = 0;
                }
            }

        }
    }
}
