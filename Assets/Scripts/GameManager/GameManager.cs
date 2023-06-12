using UnityEngine;

namespace ShootEmUp
{
    public sealed class GameManager : MonoBehaviour
    {
        [ContextMenu(nameof(FinishGame))]
        public void FinishGame() {
            Debug.Log("Game over!");
            Time.timeScale = 0;
        }
    }
}
