using AI.Blackboards;
using Elementary;
using UnityEngine;

namespace Lessons.AI.Architecture2
{
    public sealed class RootStateMachine : MonoStateMachine<RootStateMachine.StateType>
    {
        [SerializeField]
        private Blackboard blackboard;

        [BlackboardKey]
        [SerializeField]
        private string enemyKey;

        private bool isActive;

        private void FixedUpdate()
        {
            if (!this.isActive)
            {
                return;
            }
        
            var isEnemyDetected = this.blackboard.HasVariable(this.enemyKey);
            if (isEnemyDetected && this.CurrentState != StateType.ATTACK)
            {
                this.SwitchState(StateType.ATTACK);
            }
            else if (!isEnemyDetected && this.CurrentState != StateType.PATROL)
            {
                this.SwitchState(StateType.PATROL);
            }
        }

        public override void Enter()
        {
            base.Enter();
            this.isActive = true;
        }

        public override void Exit()
        {
            base.Exit();
            this.isActive = false;
        }

        public enum StateType
        {
            PATROL = 0,
            ATTACK = 1,
        }
    }
}