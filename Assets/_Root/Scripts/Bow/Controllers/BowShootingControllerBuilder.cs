using System.Collections;
using Abstractions.Controllers;
using System.Collections.Generic;
using UnityEngine;
using Abstractions.Bow;
using Abstractions.Basics;
using Controllers.Bow;
using Abstractions.Arrow;

namespace Controllers
{
    internal sealed class BowShootingControllerBuilder : IBowShootingControllerBuilder
    {
        private IArrowEventManager _arrowEventManager;
        private IBowInfo _bowInfo;
        private IArrowInfo _arrowInfo;

        public BowShootingControllerBuilder(IArrowEventManager arrowEventManager, IBowInfo bowInfo)
        {
            _arrowEventManager = arrowEventManager;
            _bowInfo = bowInfo;
        }

        public void Build(IBowInfo bowInfo)
        {
           
        }
    }
}
