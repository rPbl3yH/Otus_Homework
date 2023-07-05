using AI.Blackboards;
using AI.GOAP;
using Elementary;
using Entities;
using Game.GameEngine.Entities;
using UnityEngine;

namespace Lessons.AI.Lesson_GOAP
{
    public sealed class HarvestFactInspector : FactInspector, IBlackboardInjective
    {
        public IBlackboard Blackboard { private get; set; }

        [SerializeField]
        private ScriptableFloat minDistance;

        [Header("Blackboard")]
        [BlackboardKey]
        [SerializeField]
        private string unitKey;

        [BlackboardKey]
        [SerializeField]
        private string resourceKey;

        [Header("World State")]
        [FactId]
        [SerializeField]
        private string atResource;

        public override void OnUpdate(WorldState worldState)
        {
            if (this.Blackboard.HasVariable(this.unitKey) &&
                this.Blackboard.HasVariable(this.resourceKey))
            {
                worldState.SetFact(this.atResource, this.AtResource());
            }
            else
            {
                worldState.RemoveFact(this.atResource);
            }
        }

        private bool AtResource()
        {
            var unit = this.Blackboard.GetVariable<IEntity>(this.unitKey);
            var resource = this.Blackboard.GetVariable<IEntity>(this.resourceKey);
            var distance = EntityUtils.Distance(resource, unit);
            return distance <= this.minDistance.Current;
        }
    }
}