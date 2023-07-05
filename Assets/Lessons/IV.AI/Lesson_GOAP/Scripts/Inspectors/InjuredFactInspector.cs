using AI.Blackboards;
using AI.GOAP;
using Entities;
using Game.GameEngine.Mechanics;
using UnityEngine;

namespace Lessons.AI.Lesson_GOAP
{
    public sealed class InjuredFactInspector : FactInspector, IBlackboardInjective
    {
        public IBlackboard Blackboard { private get; set; }

        [Range(0, 1)]
        [SerializeField]
        private float hitPointsPercent;

        [Header("Blackboard")]
        [BlackboardKey]
        [SerializeField]
        private string unitKey;
        
        [Header("World State")]
        [FactId]
        [SerializeField]
        private string isInjured;

        public override void OnUpdate(WorldState worldState)
        {
            if (this.Blackboard.TryGetVariable(this.unitKey, out IEntity unit))
            {
                worldState.SetFact(this.isInjured, this.IsInjured(unit));
            }
            else
            {
                worldState.RemoveFact(this.isInjured);
            }
        }

        private bool IsInjured(IEntity unit)
        {
            var current = unit.Get<IComponent_GetHitPoints>().HitPoints;
            var max = unit.Get<IComponent_GetMaxHitPoints>().MaxHitPoints;
            var percent = (float) current / max;
            return percent <= this.hitPointsPercent;
        }
    }
}