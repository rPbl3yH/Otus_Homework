using AI.Blackboards;
using AI.GOAP;
using Entities;
using Game.GameEngine.GameResources;
using UnityEngine;

namespace Lessons.AI.Lesson_GOAP
{
    public class ResourceFactInspector : FactInspector, IBlackboardInjective
    {
        public IBlackboard Blackboard { private get; set; }
        
        [Header("Blackboard")]
        [BlackboardKey]
        [SerializeField]
        private string unitKey;

        [Header("World State")]
        [FactId]
        [SerializeField]
        private string resourceExists;

        public override void OnUpdate(WorldState worldState)
        {
            if (this.Blackboard.TryGetVariable(this.unitKey, out IEntity unit))
            {
                worldState.SetFact(this.resourceExists, this.ResourceExists(unit));
            }
            else
            {
                worldState.RemoveFact(this.resourceExists);
            }
        }

        private bool ResourceExists(IEntity unit)
        {
            return unit.Get<IComponent_ResourceSource>().GetSum() > 0;
        }
    }
}