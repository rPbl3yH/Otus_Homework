using System.Threading.Tasks;
using UnityEngine;

public class StartCounter
{
    private const int _startCount = 3;
    private int _count;
    private IStartCounterListener _observable;

    public StartCounter(IStartCounterListener observable) {
        _observable = observable;
    }

    public async void StartCount() {
        _count = _startCount;
        _observable.OnCounterChanged(_count);

        while (_count > 0) {
            await Task.Delay(1000);
            _count--;
            _observable.OnCounterChanged(_count);
        }
    }
}
