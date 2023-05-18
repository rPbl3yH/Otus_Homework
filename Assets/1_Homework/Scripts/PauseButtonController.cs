using UnityEngine;

public class PauseButtonController : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    
    public void PauseButtonClick() {
        if(_gameManager.GameState == GameState.Paused) {
            _gameManager.ResumeGame();
        }
        else if(_gameManager.GameState == GameState.Playing) {
            _gameManager.PauseGame();
        }
    }
}
