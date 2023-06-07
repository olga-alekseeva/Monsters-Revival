using Abstractions.Arrow;
using Abstractions.Controllers;
using System;
using UnityEngine;

namespace Conrtroller
{
    internal sealed class ArrowSetDamageController : IArrowSetDamageController
    {
        private IArrowInfo _arrowInfo;
        private DateTime _lastDamageTime;
        public ArrowSetDamageController(IArrowInfo arrowInfo)
        {
            _arrowInfo = arrowInfo;
            _lastDamageTime = DateTime.UtcNow;
        }

        public void OnCollisionEnter2D(Collision2D collision2D)
        {
            
        }

        public void OnCollisionStay2D(Collision2D collision2D)
        {
           
        }
    }
}
