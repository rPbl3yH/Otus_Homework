using Entities;
using Game.GameEngine.Mechanics;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.AI.Lesson_Architecture
{
    public sealed class AttackTask : Task, ITaskCallback
    {
        [SerializeField]
        private MoveTask moveTask;

        [SerializeField]
        private MeleeCombatTask combatTask;

        [Button]
        public void SetUnit(IEntity unit)
        {
            this.moveTask.SetUnit(unit);
            this.combatTask.SetUnit(unit);
        }

        [Button]
        public void SetTarget(IEntity target)
        {
            var targetPosition = target.Get<IComponent_GetPosition>().Position;
            this.moveTask.SetTargetPosition(targetPosition);
            this.combatTask.SetTarget(target);
        }

        [Button]
        public void SetStoppingDistance(float stoppingDistance)
        {
            this.moveTask.SetStoppingDistance(stoppingDistance);
        }

        protected override void Do()
        {
            this.moveTask.Do(callback: this);
        }

        protected override void OnCancel()
        {
            this.moveTask.Cancel();
            this.combatTask.Cancel();
        }

        void ITaskCallback.OnComplete(Task task, bool success)
        {
            Debug.Log("ON COMPLETE");
            if (task == this.moveTask)
            {
                Debug.Log("MOVE TASK FINISHED");
                this.combatTask.Do(callback: this);
            }
            else if (task == this.combatTask)
            {
                Debug.Log("COMBAT TASK FINISHED");
                this.Return(true);
            }
        }
    }
}