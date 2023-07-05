using System.Collections.Generic;
using AI.Blackboards;
using Lessons.AI.Lesson_BehaviourTree1;
using UnityEngine;
using Blackboard = Lessons.AI.Architecture2.Blackboard;

namespace Lessons.AI.Lesson_BehaviourTree2
{
    public sealed class AssignPositionNode : BehaviourNode
    {
        [SerializeField]
        private Blackboard blackboard;

        [SerializeField, BlackboardKey]
        private string waypointsKey;

        [SerializeField, BlackboardKey]
        private string movePositionKey;

        protected override void Run()
        {
            if (!this.blackboard.TryGetVariable(this.waypointsKey, out IEnumerator<Vector3> waypoints))
            {
                this.Return(false);
                return;
            }

            Vector3 targetPosition = waypoints.Current;
            
            if (this.blackboard.HasVariable(this.movePositionKey))
            {
                this.blackboard.ChangeVariable(this.movePositionKey, targetPosition);
            }
            else
            {
                this.blackboard.AddVariable(this.movePositionKey, targetPosition);
            }
            
            this.Return(true);
        }
    }
}