using AI.Blackboards;
using Elementary;
using Entities;
using Game.GameEngine.Mechanics;
using Lessons.AI.Architecture2;
using UnityEngine;
using Blackboard = Lessons.AI.Architecture2.Blackboard;

namespace Lessons.IV.Lesson_Architecture2
{
    public sealed class MoveToTargetState : MonoState
    {
        [SerializeField]
        private MoveAgent moveAgent;

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

        private IComponent_GetPosition targetPositionComponent;

        private void Awake()
        {
            this.enabled = false;
        }

        private void FixedUpdate()
        {
            this.moveAgent.SetTargetPosiiton(this.targetPositionComponent.Position);
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

            this.targetPositionComponent = target.Get<IComponent_GetPosition>();

            this.moveAgent.SetUnit(unit); //Unit
            this.moveAgent.SetStoppingDistance(stoppingDistance); //Stopping Distance
            this.moveAgent.SetTargetPosiiton(this.targetPositionComponent.Position);
            this.moveAgent.Play();
            
            this.enabled = true;
        }

        public override void Exit()
        {
            this.enabled = false;
            this.moveAgent.Stop();
        }
    }
}