using UnityEngine;

namespace Abstractions.Controllers.Arrow
{
    internal interface IArrowStarter
    {
        public void ArrowStart(Vector3 position, Quaternion rotation, float shootingForce);
    }
}