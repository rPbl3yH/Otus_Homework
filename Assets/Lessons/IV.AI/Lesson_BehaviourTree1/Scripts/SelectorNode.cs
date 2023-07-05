using UnityEngine;

namespace Lessons.AI.Lesson_BehaviourTree1
{
    public sealed class SelectorNode : BehaviourNode, BehaviourNode.ICallback
    {
        [SerializeField]
        private BehaviourNode[] children;

        private BehaviourNode currentChild;
        
        private int pointer;
        
        protected override void Run()
        {
            if (this.children.Length <= 0)
            {
                this.Return(false);
                return;
            }

            this.pointer = 0;
            this.currentChild = this.children[0];
            this.currentChild.Run(callback: this);
        }

        void BehaviourNode.ICallback.Invoke(BehaviourNode node, bool result)
        {
            if (result)
            {
                this.currentChild = null;
                this.Return(true);
                return;
            }

            if (this.pointer + 1 >= this.children.Length)
            {
                this.currentChild = null;
                this.Return(false);
                return;
            }

            this.pointer++;
            this.currentChild = this.children[this.pointer];
            this.currentChild.Run(callback: this);
        }

        protected override void OnAbort()
        {
            if (this.currentChild != null && this.currentChild.IsRunning)
            {
                this.currentChild.Abort();
            }
        }
    }
}