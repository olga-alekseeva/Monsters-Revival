using Abstractions.Controllers;
using Settings;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Controllers
{
    internal sealed class PlayerExitPortalController : IPlayerExitPortalController
    {
        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag(TagNames.PORTAL))
            {
                SceneManager.LoadScene(SceneNames.SAMPLE_SCENE);
            }
        }
    }
}
