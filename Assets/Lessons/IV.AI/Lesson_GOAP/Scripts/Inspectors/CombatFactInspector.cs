using AI.Blackboards;
using AI.GOAP;
using Elementary;
using Entities;
using Game.GameEngine.Entities;
using Game.GameEngine.Mechanics;
using UnityEngine;

namespace Lessons.AI.Lesson_GOAP
{
    public sealed class CombatFactInspector : FactInspector, IBlackboardInjective
    {
        public IBlackboard Blackboard { private get; set; }

        [Space]
        [SerializeField]
        private FloatAdapter meleeDistance;

        [SerializeField]
        private FloatAdapter rangeDistance;
        
        [Header("Blackboard")]
        [BlackboardKey]
        [SerializeField]
        private string unitKey;

        [BlackboardKey]
        [SerializeField]
        private string targetKey;

        [Header("World State")]
        [FactId]
        [SerializeField]
        private string enemyAlive;

        [FactId]
        [SerializeField]
        private string nearEnemy;

        [FactId]
        [SerializeField]
        private string atEnemy;

        public override void OnUpdate(WorldState worldState)
        {
            if (this.Blackboard.TryGetVariable(this.unitKey, out IEntity unit) &&
                this.Blackboard.TryGetVariable(this.targetKey, out IEntity target))
            {
                var distance = EntityUtils.Distance(unit, target);

                worldState.SetFact(this.enemyAlive, target.Get<IComponent_IsAlive>().IsAlive);
                worldState.SetFact(this.nearEnemy, distance <= this.rangeDistance.Current);
                worldState.SetFact(this.atEnemy, distance <= this.meleeDistance.Current);
            }
            else
            {
                worldState.RemoveFact(this.enemyAlive);
                worldState.RemoveFact(this.nearEnemy);
                worldState.RemoveFact(this.atEnemy);
            }
        }
    }
}