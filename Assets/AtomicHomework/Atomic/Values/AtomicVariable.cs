using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Gameplay.Atomic1
{
    [Serializable]
    public class AtomicVariable<T> : IAtomicVariable<T>
    {
        public AtomicEvent<T> OnChanged { get; set; } = new();

        public T Value
        {
            get { return this.value; }
            set
            {
                this.value = value;
                this.OnChanged?.Invoke(value);
            }
        }

        [OnValueChanged("OnValueChanged")]
        [SerializeField]
        private T value;

        public AtomicVariable()
        {
            this.value = default;
        }

        public AtomicVariable(T value)
        {
            this.value = value;
        }

#if UNITY_EDITOR
        private void OnValueChanged(T value)
        {
            this.OnChanged?.Invoke(value);
        }
#endif
    }
}