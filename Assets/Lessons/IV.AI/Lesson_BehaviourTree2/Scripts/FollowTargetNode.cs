using System.Collections;
using AI.Blackboards;
using Entities;
using Game.GameEngine.Mechanics;
using Lessons.AI.Lesson_Architecture;
using Lessons.AI.Lesson_BehaviourTree1;
using UnityEngine;
using Blackboard = Lessons.AI.Architecture2.Blackboard;

namespace Lessons.AI.Lesson_BehaviourTree2
{
    public sealed class FollowTargetNode : BehaviourNode, ITaskCallback
    {
        [SerializeField]
        private MoveTask moveTask;

        [Space]
        [SerializeField]
        private Blackboard blackboard;

        [BlackboardKey]
        [SerializeField]
        private string unitKey;

        [BlackboardKey]
        [SerializeField]
        private string targetKey;

        [BlackboardKey]
        [SerializeField]
        private string stoppingDistanceKey;

        private IComponent_GetPosition targetComponent;

        private Coroutine updateCoroutine;

        protected override void Run()
        {
            if (!this.blackboard.TryGetVariable(this.unitKey, out IEntity unit))
            {
                this.Return(false);
                return;
            }

            if (!this.blackboard.TryGetVariable(this.targetKey, out IEntity target))
            {
                this.Return(false);
                return;
            }

            if (!this.blackboard.TryGetVariable(this.stoppingDistanceKey, out float stoppingDistance))
            {
                this.Return(false);
                return;
            }

            this.targetComponent = target.Get<IComponent_GetPosition>();
            this.updateCoroutine = this.StartCoroutine(this.UpdatePositionRoutine());

            this.moveTask.SetUnit(unit);
            this.moveTask.SetStoppingDistance(stoppingDistance);
            this.moveTask.Do(callback: this);
        }

        private IEnumerator UpdatePositionRoutine()
        {
            var period = new WaitForFixedUpdate();
            while (true)
            {
                this.moveTask.SetTargetPosition(this.targetComponent.Position);
                yield return period;
            }
        }

        void ITaskCallback.OnComplete(Task task, bool success)
        {
            if (this.updateCoroutine != null)
            {
                this.StopCoroutine(this.updateCoroutine);
                this.updateCoroutine = null;
            }
            
            this.Return(true);
        }

        protected override void OnAbort()
        {
            if (this.updateCoroutine != null)
            {
                this.StopCoroutine(this.updateCoroutine);
                this.updateCoroutine = null;
            }

            this.moveTask.Cancel();
        }
    }
}