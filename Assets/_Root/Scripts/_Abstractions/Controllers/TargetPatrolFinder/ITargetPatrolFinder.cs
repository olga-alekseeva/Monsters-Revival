using UnityEngine;

namespace Abstractions.Controllers
{
    internal interface ITargetPatrolFinder
    {
        Vector3 GetPatrolTarget(Vector3 currentPosition);
    }
}