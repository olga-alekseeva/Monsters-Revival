using Abstractions.Controllers;
using Settings;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UI.Image;

namespace Controllers.Patrol
{
    internal sealed class TargetPatrolFinder : ITargetPatrolFinder
    {
        private const float MAX_DISTANCE = 100f;

        private LayerMask _mask;

        public TargetPatrolFinder()
        {
            _mask = LayerMask.GetMask(LayerNames.WALL, LayerNames.UNIT_OBSTACLE);
        }

        public Vector3 GetPatrolTarget(Vector3 currentPosition)
        {
            float xRandom = Random.Range(-1f, 1f);
            float yRandom = Random.Range(-1f, 1f);
            Vector2 direction = new Vector2(xRandom, yRandom).normalized;

            RaycastHit2D raycastHit2D = Physics2D.Raycast(currentPosition, direction, MAX_DISTANCE, _mask.value);

            float randomDistance = 0f;
            if (raycastHit2D.collider == null)
            {
                randomDistance = Random.Range(0, MAX_DISTANCE);
            }
            else
            {
                randomDistance = Random.Range(0, raycastHit2D.distance);
            }

            return currentPosition + ((Vector3)direction * randomDistance);
        }
    }
}
