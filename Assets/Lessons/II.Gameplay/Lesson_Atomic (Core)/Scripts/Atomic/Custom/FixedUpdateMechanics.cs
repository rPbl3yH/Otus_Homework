using System;
using Declarative;

namespace Lessons.Gameplay.Atomic1
{
    public sealed class FixedUpdateMechanics : IFixedUpdateListener
    {
        private Action<float> update;

        public void Do(Action<float> update)
        {
            this.update = update;
        }
    
        void IFixedUpdateListener.FixedUpdate(float deltaTime)
        {
            this.update.Invoke(deltaTime);
        }
    }
}