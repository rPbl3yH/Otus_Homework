using Sirenix.OdinInspector;

namespace Lessons.Gameplay.Atomic1
{
    public sealed class AtomicAction : IAtomicAction
    {
        private readonly System.Action action;

        public AtomicAction(System.Action action)
        {
            this.action = action;
        }

        [Button]
        public void Invoke()
        {
            this.action?.Invoke();
        }
    }

    public sealed class AtomicAction<T> : IAtomicAction<T>
    {
        private readonly System.Action<T> action;

        public AtomicAction(System.Action<T> action)
        {
            this.action = action;
        }

        [Button]
        public void Invoke(T args)
        {
            this.action?.Invoke(args);
        }
    }
}