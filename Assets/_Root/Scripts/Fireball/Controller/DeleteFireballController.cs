using Abstractions.Controllers;
using Abstractions.Fireball;
using Fireball;
using UnityEngine;

namespace Controllers
{
    internal sealed class DeleteFireballController : IDeleteFireballController
    {
        private IFireballInfo _fireballInfo;

        public DeleteFireballController(IFireballInfo fireballInfo)
        {
            _fireballInfo = fireballInfo;
        }

        public void Update(float deltaTime)
        {
            if (!_fireballInfo.IsPreset())
            {
                return;
            }

            if (Input.GetMouseButtonDown(1))
            {
                _fireballInfo.DestroyFirst();
            }

        }
    }
}
