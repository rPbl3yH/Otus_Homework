using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Off,
    Playing,
    Paused,
    Finished
}

public class GameManager : MonoBehaviour
{
    public GameState GameState => _gameState;

    private GameState _gameState;
    private List<IGameListener> _listeners = new();
    private List<IGameUpdateListener> _updateListeners = new();
    private List<IGameLateUpdateListener> _lateUpdatesListeners = new();
    private ObstacleHitObservable _obstacleHitObservable;

    private void Update() {
        if (_gameState == GameState.Playing) {
            var deltaTime = Time.deltaTime;
            
            foreach (var updateListener in _updateListeners) {
                updateListener.OnUpdate(deltaTime);
            }
        }
    }

    private void LateUpdate() {
        if(_gameState == GameState.Playing) {
            var deltaTime = Time.deltaTime;

            foreach(var updateListener in _lateUpdatesListeners) {
                updateListener.OnLateUpdate(deltaTime);
            }
        }
    }

    public void AddListeners(IGameListener[] gameListeners) {
        foreach (var gameListener in gameListeners) {
            AddListener(gameListener);
        }
    }

    public void AddListener(IGameListener gameListener) {
        _listeners.Add(gameListener);

        if (gameListener is IGameUpdateListener gameUpdateListener) {
            _updateListeners.Add(gameUpdateListener);
        }

        if (gameListener is IGameLateUpdateListener gameLateUpdateListener) {
            _lateUpdatesListeners.Add(gameLateUpdateListener);
        }
    }

    public void InitGame() {
        foreach (var gameListener in _listeners) {
            if(gameListener is IGameInitListener gameInitListener) {
                gameInitListener.OnGameInit();
            }
        }
    }

    [ContextMenu("Start game")]
    public void StartGame() {
        if(_gameState == GameState.Playing || _gameState == GameState.Paused) {
            return;
        }

        _obstacleHitObservable = new ObstacleHitObservable(this);
        var obstacles = FindObjectsOfType<Obstacle>();

        foreach (var obstacle in obstacles) {
            obstacle.Init(_obstacleHitObservable);
        }

        foreach (var gameListener in _listeners) {
            if (gameListener is IGameStartListener gameStartListener) {
                gameStartListener.OnGameStarted();
            }
        }

        SetState(GameState.Playing);
    }

    public void FinishGame() {
        if(_gameState == GameState.Finished) {
            return;
        }

        foreach (var gameListener in _listeners) {
            if (gameListener is IGameFinishListener gameFinishListener) {
                gameFinishListener.OnGameFinished();
            }
        }

        SetState(GameState.Finished);
    }

    public void PauseGame() {
        if(_gameState == GameState.Paused) {
            return;
        }

        foreach (var gameListener in _listeners) {
            if(gameListener is IGamePauseListener gamePauseListener) {
                gamePauseListener.OnGamePaused();
            }
        }

        SetState(GameState.Paused);
    }

    public void ResumeGame() {
        if(_gameState == GameState.Playing) {
            return;
        }

        foreach(var gameListener in _listeners) {
            if(gameListener is IGameResumeListener gameResumeListener) {
                gameResumeListener.OnGameResumed();
            }
        }

        SetState(GameState.Playing);
    }

    private void SetState(GameState gameState) {
        _gameState = gameState;
        print($"Current game state = {gameState}");
    }
}
