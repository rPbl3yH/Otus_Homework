using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Off,
    Playing,
    Paused,
    Finished
}

public class GameManager : MonoBehaviour, IStartCounterFinishListener
{
    [SerializeField] private GameUI _gameUI;
    private GameState _gameState;
    private List<IGameListener> _listeners = new();
    private List<IGameUpdateListener> _updateListeners = new();
    private List<IGameLateUpdateListener> _lateUpdatesListeners = new();
    private StartCounter _startCounter;

    private void Awake() {
        var listeners = GetComponentsInChildren<IGameListener>();
        print(listeners.Length);

        foreach (IGameListener gameListener in listeners) {
            AddListener(gameListener);
        }
    }

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

    public void AddListener(IGameListener gameListener) {
        _listeners.Add(gameListener);

        if (gameListener is IGameUpdateListener gameUpdateListener) {
            _updateListeners.Add(gameUpdateListener);
        }

        if (gameListener is IGameLateUpdateListener gameLateUpdateListener) {
            _lateUpdatesListeners.Add(gameLateUpdateListener);
        }
    }

    public void StartLevel() {
        StartCounterListener startCounterObserver = new StartCounterListener(this, _gameUI.GetCounterText());
        _startCounter = new StartCounter(startCounterObserver);
        _startCounter.StartCount();
    }

    public void OnStartCountFinished() {
        StartGame();
    }

    [ContextMenu("Start game")]
    private void StartGame() {
        foreach (var gameListener in _listeners) {
            if (gameListener is IGameStartListener gameStartListener) {
                gameStartListener.OnGameStarted();
            }
        }

        _gameState = GameState.Playing;
    }

    [ContextMenu("Finish game")]
    private void FinishGame() {
        foreach (var gameListener in _listeners) {
            if (gameListener is IGameFinishListener gameFinishListener) {
                gameFinishListener.OnGameFinish();
            }
        }
        _gameState = GameState.Finished;
    }
}
