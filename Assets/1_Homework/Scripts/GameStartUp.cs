using System;
using System.Threading.Tasks;
using UnityEngine;

public class GameStartUp : MonoBehaviour 
{
    public event Action<int> OnCountChanged;

    [SerializeField] private GameManager _gameManager;

    private const int _startCount = 3;
    private int _count;

    public async void StartCount() {
        _count = _startCount;
        OnCountChanged?.Invoke(_count);

        while (_count > 0) {
            await Task.Delay(1000);
            _count--;
            OnCountChanged(_count);
        }

        _gameManager.StartGame();
    }
}
