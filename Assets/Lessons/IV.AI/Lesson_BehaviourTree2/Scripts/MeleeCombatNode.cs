using AI.Blackboards;
using Entities;
using Game.GameEngine.Mechanics;
using Lessons.AI.Lesson_BehaviourTree1;
using UnityEngine;
using Blackboard = Lessons.AI.Architecture2.Blackboard;

namespace Lessons.AI.Lesson_BehaviourTree2
{
    public sealed class MeleeCombatNode : BehaviourNode
    {
        [SerializeField]
        private Blackboard blackboard;

        [BlackboardKey]
        [SerializeField]
        private string unitKey;

        [BlackboardKey]
        [SerializeField]
        private string targetKey;

        [SerializeField]
        private bool success = true;

        private IComponent_MeleeCombat unitComponent;

        protected override void Run()
        {
            if (!this.blackboard.TryGetVariable(this.unitKey, out IEntity unit))
            {
                this.Return(false);
                return;
            }

            if (!this.blackboard.TryGetVariable(this.targetKey, out IEntity target))
            {
                this.Return(false);
                return;
            }

            this.unitComponent = unit.Get<IComponent_MeleeCombat>();
            this.StartCombat(target);
        }

        private void StartCombat(IEntity target)
        {
            if (this.unitComponent.IsCombat)
            {
                this.unitComponent.StopCombat();
            }

            this.unitComponent.OnCombatStopped += this.OnCombatFinished;
            
            var operation = new CombatOperation(target);
            
            if (this.unitComponent.CanStartCombat(operation))
            {
                this.unitComponent.StartCombat(operation);
            }
            else
            {
                this.Return(this.success);
            }
        }

        private void OnCombatFinished(CombatOperation obj)
        {
            this.unitComponent.OnCombatStopped -= this.OnCombatFinished;
            this.Return(this.success);
        }

        protected override void OnAbort()
        {
            this.unitComponent.OnCombatStopped -= this.OnCombatFinished;
            if (this.unitComponent.IsCombat)
            {
                this.unitComponent.StopCombat();
            }
        }
    }
}