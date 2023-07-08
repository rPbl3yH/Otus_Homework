using System;
using Declarative;

namespace AtomicHomework.Atomic.Custom
{
    public class UpdateMechanics: IUpdateListener
    {
        private Action<float> _onUpdate;

        public void OnUpdate(Action<float> action)
        {
            _onUpdate = action;
        }

        public void Update(float deltaTime)
        {
            _onUpdate?.Invoke(deltaTime);
        }
    }
}