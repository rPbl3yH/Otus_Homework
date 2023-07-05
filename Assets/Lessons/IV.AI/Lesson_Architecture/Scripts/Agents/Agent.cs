using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.AI.Lesson_Architecture
{
    public abstract class Agent : SerializedMonoBehaviour
    {
        public event Action OnStarted;

        public event Action OnStopped;

        [ShowInInspector, ReadOnly]
        public bool IsPlaying
        {
            get { return this.isPlaying; }
        }

        private bool isPlaying;

        [Button]
        public void Play()
        {
            if (this.isPlaying)
            {
                Debug.LogWarning("Agent is already started!");
                return;
            }
            
            this.isPlaying = true;
            this.OnStart();
            this.OnStarted?.Invoke();
        }

        [Button]
        public void Stop()
        {
            if (!this.isPlaying)
            {
                Debug.LogWarning("Agent is not started!");
                return;
            }

            this.isPlaying = false;
            this.OnStop();
            this.OnStopped?.Invoke();
        }

        protected abstract void OnStart();

        protected abstract void OnStop();
    }
}