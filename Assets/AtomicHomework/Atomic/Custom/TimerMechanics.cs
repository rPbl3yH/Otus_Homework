using System;
using UnityEngine;

namespace AtomicHomework.Atomic.Custom
{
    public class TimerMechanics : MonoBehaviour
    {
        public event Action OnTimerFinished;
        
        private float _timer;
        private float _targetTime;
        private bool _isEnabled;
        
        private void Update()
        {
            if (!_isEnabled)
            {
                return;
            }
            
            _timer += Time.deltaTime;
            
            if (_timer >= _targetTime)
            {
                _timer = 0;
                OnTimerFinished?.Invoke();
            }
        }

        public void Construct(float targetTime)
        {
            _targetTime = targetTime;
        }

        public void StartTimer()
        {
            _isEnabled = true;
        }

        public void StopTimer()
        {
            _timer = 0;
            _isEnabled = false;
        }
    }
}