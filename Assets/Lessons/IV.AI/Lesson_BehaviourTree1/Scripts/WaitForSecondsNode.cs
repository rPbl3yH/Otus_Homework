using System.Collections;
using UnityEngine;

namespace Lessons.AI.Lesson_BehaviourTree1
{
    public sealed class WaitForSecondsNode : BehaviourNode
    {
        [SerializeField]
        private float seconds;

        [SerializeField]
        private bool success;

        private Coroutine coroutine;

        protected override void Run()
        {
            this.coroutine = this.StartCoroutine(this.WaitForSeconds());
        }

        protected override void OnAbort()
        {
            if (this.coroutine != null)
            {
                this.StopCoroutine(this.coroutine);
                this.coroutine = null;
            }
        }

        private IEnumerator WaitForSeconds()
        {
            yield return new WaitForSeconds(this.seconds);
            this.coroutine = null;
            this.Return(this.success);
        }
    }
}