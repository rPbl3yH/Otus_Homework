using System;
using System.Collections.Generic;

namespace Lessons.Utils
{
    public sealed class AtomicEvent
    {
        private readonly List<Action> _actions = new();
        private int _index;
        
        public static AtomicEvent operator+(AtomicEvent atomicEvent, Action action)
        {
            atomicEvent._actions.Add(action);
            return atomicEvent;
        }

        public static AtomicEvent operator-(AtomicEvent atomicEvent, Action action)
        {
            atomicEvent._actions.Remove(action);
            atomicEvent._index--;
            
            return atomicEvent;
        }

        public void Invoke()
        {
            for (_index = 0; _index < _actions.Count; ++_index)
            {
                var action = _actions[_index];
                action.Invoke();
            }
        }
    }

    public sealed class AtomicEvent<T>
    {
        private readonly List<Action<T>> _actions = new();
        private int _index;
        
        public static AtomicEvent<T> operator+(AtomicEvent<T> atomicEvent, Action<T> action)
        {
            atomicEvent._actions.Add(action);
            return atomicEvent;
        }

        public static AtomicEvent<T> operator-(AtomicEvent<T> atomicEvent, Action<T> action)
        {
            atomicEvent._actions.Remove(action);
            atomicEvent._index--;
            
            return atomicEvent;
        }

        public void Invoke(T arg)
        {
            for (_index = 0; _index < _actions.Count; ++_index)
            {
                _actions[_index].Invoke(arg);
            }
        }
    }
}