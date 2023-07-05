using AI.Blackboards;
using Elementary;
using Entities;
using UnityEngine;

namespace Lessons.AI.Architecture2
{
    public sealed class MeleeCombatState : MonoState
    {
        [SerializeField]
        private Blackboard blackboard;

        [SerializeField]
        private MeleeCombatAgent agent;

        [BlackboardKey]
        [SerializeField]
        private string unitKey;

        [BlackboardKey]
        [SerializeField]
        private string targetKey;

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
            
            this.agent.SetUnit(unit);
            this.agent.SetTarget(target);
            this.agent.Play();
        }

        public override void Exit()
        {
            this.agent.Stop();
        }
    }
}