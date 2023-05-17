using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    private List<IGameListener> _listeners = new();
    private List<IGameUpdateListener> _updateListeners = new();

    private void Awake() {
        var listeners = GetComponentsInChildren<IGameListener>();
        print(listeners.Length);
       
        foreach(IGameListener gameListener in listeners) {
            AddListener(gameListener);
        }
    }

    private void Update() {
        var deltaTime = Time.deltaTime;

        foreach (var updateListener in _updateListeners) {
            updateListener.OnUpdate(deltaTime);
        }
    }

    public void AddListener(IGameListener gameListener) {
        _listeners.Add(gameListener);

        if (gameListener is IGameUpdateListener gameUpdateListener) {
            _updateListeners.Add(gameUpdateListener);
        }
    }

    [ContextMenu("Start game")]
    public void StartGame() {
        foreach (var gameListener in _listeners) {
            if(gameListener is IGameStartListener gameStartListener) {
                gameStartListener.OnGameStarted();
            }
        }
    }

    [ContextMenu("Finish game")]
    public void FinishGame() {
        foreach (var gameListener in _listeners) {
            if(gameListener is IGameFinishListener gameFinishListener) {
                gameFinishListener.OnGameFinish();
            }
        }
    }
}
