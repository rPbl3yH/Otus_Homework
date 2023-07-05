using System.Collections;
using System.Collections.Generic;
using AI.Blackboards;
using Elementary;
using Entities;
using UnityEngine;

namespace Lessons.AI.Architecture2
{
    public sealed class PatrolState : MonoStateCoroutine
    {
        [SerializeField]
        private MoveAgent moveAgent;

        [Space]
        [SerializeField]
        private Blackboard blackboard;

        [BlackboardKey]
        [SerializeField]
        private string unitKey;

        [BlackboardKey]
        [SerializeField]
        private string waypointsKey;

        [BlackboardKey]
        [SerializeField]
        private string stoppingDistanceKey;

        [BlackboardKey]
        [SerializeField]
        private string patrolDelayKey;

        private float patrolDelay;

        private IEnumerator<Vector3> waypointIterator;

        public override void Enter()
        {
            if (!this.blackboard.TryGetVariable(this.unitKey, out IEntity unit))
            {
                return;
            }

            if (!this.blackboard.TryGetVariable(this.stoppingDistanceKey, out float stoppingDistance))
            {
                return;
            }

            if (!this.blackboard.TryGetVariable(this.waypointsKey, out this.waypointIterator))
            {
                return;
            }

            if (!this.blackboard.TryGetVariable(this.patrolDelayKey, out this.patrolDelay))
            {
                return;
            }

            this.moveAgent.SetUnit(unit);
            this.moveAgent.SetStoppingDistance(stoppingDistance);
            this.moveAgent.SetTargetPosiiton(this.waypointIterator.Current);
            this.moveAgent.Play();

            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();

            if (this.moveAgent.IsPlaying)
            {
                this.moveAgent.Stop();
            }
        }

        protected override IEnumerator Do()
        {
            var period = new WaitForFixedUpdate();
            while (true)
            {
                if (this.moveAgent.IsPositionReached)
                {
                    yield return new WaitForSeconds(this.patrolDelay);
                    this.NextPosition();
                }

                yield return period;
            }
        }

        private void NextPosition()
        {
            if (this.waypointIterator.MoveNext())
            {
                var nextPosition = this.waypointIterator.Current;
                this.moveAgent.SetTargetPosiiton(nextPosition);
            }
        }
    }
}