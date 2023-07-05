using System.Collections.Generic;
using AI.Blackboards;
using Lessons.AI.Lesson_BehaviourTree1;
using UnityEngine;
using Blackboard = Lessons.AI.Architecture2.Blackboard;

namespace Lessons.AI.Lesson_BehaviourTree2
{
    public sealed class NextWaypointNode : BehaviourNode
    {
        [SerializeField]
        private Blackboard blackboard;

        [SerializeField, BlackboardKey]
        private string waypointsKey;

        protected override void Run()
        {
            if (!this.blackboard.TryGetVariable(this.waypointsKey, out IEnumerator<Vector3> waypoints))
            {
                this.Return(false);
                return;
            }

            waypoints.MoveNext();
            this.Return(true);
        }
    }
}