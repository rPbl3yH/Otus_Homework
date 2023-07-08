using System;
using Declarative;

namespace AtomicHomework.Atomic.Custom
{
    public class LateUpdateMechanics: ILateUpdateListener
    {
        private Action<float> _onUpdate;

        public void OnUpdate(Action<float> action)
        {
            _onUpdate = action;
        }

        public void LateUpdate(float deltaTime)
        {
            _onUpdate?.Invoke(deltaTime);
        }
    }
}