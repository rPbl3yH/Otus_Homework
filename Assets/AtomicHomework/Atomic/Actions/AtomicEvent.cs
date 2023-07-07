using System.Collections.Generic;
using Sirenix.OdinInspector;

namespace Lessons.Gameplay.Atomic1
{
    public sealed class AtomicEvent : IAtomicAction
    {
        private readonly List<IAtomicAction> actions = new();
        private readonly List<IAtomicAction> cache = new();
        private readonly Dictionary<System.Action, IAtomicAction> delegates = new();

        public static AtomicEvent operator +(AtomicEvent composite, IAtomicAction action)
        {
            composite.actions.Add(action);
            return composite;
        }

        public static AtomicEvent operator +(AtomicEvent composite, System.Action @delegate)
        {
            var action = new AtomicAction(@delegate);
            composite.actions.Add(action);
            composite.delegates[@delegate] = action;
            return composite;
        }

        public static AtomicEvent operator -(AtomicEvent composite, IAtomicAction action)
        {
            composite.actions.Remove(action);
            return composite;
        }

        public static AtomicEvent operator -(AtomicEvent composite, System.Action @delegate)
        {
            if (composite.delegates.TryGetValue(@delegate, out var action))
            {
                composite.delegates.Remove(@delegate);
                composite.actions.Remove(action);
            }

            return composite;
        }

        [Button]
        public void Invoke()
        {
            this.cache.Clear();
            this.cache.AddRange(this.actions);

            for (int i = 0, count = this.cache.Count; i < count; i++)
            {
                var action = this.cache[i];
                action.Invoke();
            }
        }
    }

    public class AtomicEvent<T> : IAtomicAction<T>
    {
        private readonly List<IAtomicAction<T>> actions = new();
        private readonly Dictionary<System.Action<T>, IAtomicAction<T>> delegates = new();
        private readonly List<IAtomicAction<T>> cache = new();

        public static AtomicEvent<T> operator +(AtomicEvent<T> composite, IAtomicAction<T> action)
        {
            composite.actions.Add(action);
            return composite;
        }

        public static AtomicEvent<T> operator +(AtomicEvent<T> composite, System.Action<T> @delegate)
        {
            var action = new AtomicAction<T>(@delegate);
            composite.actions.Add(action);
            composite.delegates[@delegate] = action;
            return composite;
        }

        public static AtomicEvent<T> operator -(AtomicEvent<T> composite, IAtomicAction<T> action)
        {
            composite.actions.Remove(action);
            return composite;
        }

        public static AtomicEvent<T> operator -(AtomicEvent<T> composite, System.Action<T> @delegate)
        {
            if (composite.delegates.TryGetValue(@delegate, out var action))
            {
                composite.delegates.Remove(@delegate);
                composite.actions.Remove(action);
            }

            return composite;
        }

        [Button]
        public void Invoke(T args)
        {
            this.cache.Clear();
            this.cache.AddRange(this.actions);

            for (int i = 0, count = this.cache.Count; i < count; i++)
            {
                var action = this.cache[i];
                action.Invoke(args);
            }
        }
    }
}