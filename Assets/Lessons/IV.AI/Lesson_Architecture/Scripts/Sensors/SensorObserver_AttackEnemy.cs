using Elementary;
using Entities;
using Lessons.AI.Lesson_Architecture;
using UnityEngine;

namespace Lessons.AI.Architecture
{
    public sealed class SensorObserver_AttackEnemy : ColliderDetectionHandler
    {
        [SerializeField]
        private AttackAgent attackAgent;

        private IEntity target;

        protected override void OnCollidersUpdated(Collider[] buffer, int size)
        {
            if (size > 0 && this.target == null)
            {
                this.target = buffer[0].GetComponent<IEntity>();
                this.attackAgent.SetTarget(this.target);
                return;
            }

            if (size <= 0 && this.target != null)
            {
                this.attackAgent.SetTarget(null);
                this.target = null;
            }
        }
    }
}