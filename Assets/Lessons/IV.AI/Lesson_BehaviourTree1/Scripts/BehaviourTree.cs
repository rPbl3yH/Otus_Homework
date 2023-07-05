using System;
using UnityEngine;

namespace Lessons.AI.Lesson_BehaviourTree1
{
    public sealed class BehaviourTree : BehaviourNode, BehaviourNode.ICallback
    {
        public event Action OnStarted;

        public event Action<bool> OnFinished;

        public event Action OnAborted;

        [SerializeField]
        private BehaviourNode root;

        [Space]
        [SerializeField]
        private bool runOnStart;

        [SerializeField]
        private bool loop;

        private void Start()
        {
            if (this.runOnStart)
            {
                this.Run(null);
            }
        }

        private void FixedUpdate()
        {
            if (this.loop && !this.IsRunning)
            {
                this.Run(null);
            }
        }

        protected override void Run()
        {
            this.OnStarted?.Invoke();
            this.root.Run(this);
        }

        protected override void OnAbort()
        {
            if (this.root.IsRunning)
            {
                this.root.Abort();
            }
            
            this.OnAborted?.Invoke();
        }

        void ICallback.Invoke(BehaviourNode node, bool success)
        {
            this.Return(success);
            this.OnFinished?.Invoke(success);
        }
    }
}