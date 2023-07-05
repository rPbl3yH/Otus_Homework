using AI.Blackboards;
using Elementary;
using Entities;
using Game.GameEngine.Mechanics;
using UnityEngine;

namespace Lessons.AI.Architecture2
{
    public sealed class AttackStateMachine : MonoStateMachine<AttackStateMachine.StateType>
    {
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

        private IComponent_GetPosition unitComponent;

        private IComponent_GetPosition targetComponent;

        private float stoppingDistanceSqr;

        private void Awake()
        {
            this.enabled = false;
        }

        private void FixedUpdate()
        {
            if (this.targetComponent != null && this.unitComponent != null)
            {
                this.UpdateState();
            }
        }

        public override void Enter()
        {
            if (!this.blackboard.TryGetVariable(this.unitKey, out IEntity unit))
            {
                return;
            }

            if (!this.blackboard.TryGetVariable(this.targetKey, out IEntity target))
            {
                return;
            }

            if (!this.blackboard.TryGetVariable(this.stoppingDistanceKey, out float stoppingDistance))
            {
                return;
            }

            this.unitComponent = unit.Get<IComponent_GetPosition>();
            this.targetComponent = target.Get<IComponent_GetPosition>();
            this.stoppingDistanceSqr = stoppingDistance * stoppingDistance;

            base.Enter();
            this.enabled = true;
        }

        public override void Exit()
        {
            base.Exit();
            this.enabled = false;
        }

        private void UpdateState()
        {
            var unitPosition = this.unitComponent.Position;
            var targetPosition = this.targetComponent.Position;

            var distance = unitPosition - targetPosition;
            var distanceReached = distance.sqrMagnitude <= this.stoppingDistanceSqr;

            if (distanceReached && this.CurrentState != StateType.COMBAT)
            {
                this.SwitchState(StateType.COMBAT);
            }
            else if (!distanceReached && this.CurrentState != StateType.FOLLOW)
            {
                this.SwitchState(StateType.FOLLOW);
            }
        }

        public enum StateType
        {
            FOLLOW = 0,
            COMBAT = 1
        }
    }
}