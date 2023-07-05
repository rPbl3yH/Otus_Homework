using AI.Blackboards;
using Elementary;
using Entities;
using UnityEngine;

namespace Lessons.AI.Lesson_GOAP
{
    public sealed class OpponentDetection : ColliderDetectionHandler
    {
        [Space]
        [SerializeField]
        private UnityBlackboard blackboard;

        [BlackboardKey]
        [SerializeField]
        private string enemyKey;

        [Space]
        [SerializeReference]
        private IEntityCondition enemyCondition;

        private IEntity enemy;

        protected override void OnCollidersUpdated(Collider[] buffer, int size)
        {
            if (this.enemy == null)
            {
                if (this.FindTarget(buffer, size, out this.enemy))
                {
                    Debug.Log("Detect Enemy");
                    this.blackboard.AddVariable(this.enemyKey, this.enemy);
                }
            }
            else
            {
                if (!this.IsTargetExists(buffer, size, this.enemy))
                {
                    Debug.Log("Undetect Enemy");
                    this.blackboard.RemoveVariable(this.enemyKey);
                    this.enemy = null;
                }
            }
        }

        private bool FindTarget(Collider[] buffer, int size, out IEntity target)
        {
            for (var i = 0; i < size; i++)
            {
                var collder = buffer[i];
                if (collder.TryGetComponent(out IEntity entity) && this.enemyCondition.IsTrue(entity))
                {
                    target = entity;
                    return true;
                }
            }

            target = default;
            return false;
        }

        private bool IsTargetExists(Collider[] buffer, int size, IEntity target)
        {
            for (var i = 0; i < size; i++)
            {
                var collder = buffer[i];
                if (collder.TryGetComponent(out IEntity entity) && target == entity)
                {
                    return true;
                }
            }

            return false;
        }
    }
}