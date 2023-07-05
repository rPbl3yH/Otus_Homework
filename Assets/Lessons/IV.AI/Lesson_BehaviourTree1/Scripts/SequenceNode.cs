using UnityEngine;

namespace Lessons.AI.Lesson_BehaviourTree1
{
    public sealed class SequenceNode : BehaviourNode, BehaviourNode.ICallback
    {
        [SerializeField]
        private BehaviourNode[] children;

        private BehaviourNode currentNode;

        private int pointer;

        protected override void Run()
        {
            if (this.children.Length == 0)
            {
                this.Return(true);
                return;
            }

            this.pointer = 0;
            this.currentNode = this.children[0];
            this.currentNode.Run(callback: this);
        }

        void ICallback.Invoke(BehaviourNode node, bool success)
        {
            if (!success)
            {
                this.currentNode = null;
                this.Return(false);
                return;
            }

            if (this.pointer + 1 >= this.children.Length)
            {
                this.currentNode = null;
                this.Return(true);
                return;
            }
            
            this.pointer++;
            this.currentNode = this.children[this.pointer];
            this.currentNode.Run(callback: this);
        }

        protected override void OnAbort()
        {
            if (this.currentNode != null && this.currentNode.IsRunning) 
            {
                this.currentNode.Abort();
            }
        }
    }
}