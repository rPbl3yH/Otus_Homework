using AI.GOAP;
using Entities;
using Game.GameEngine.Mechanics;
using UnityEngine;
using UnityEngine.Serialization;

namespace Lessons.AI.Lesson_GOAP
{
    public sealed class HappyFactInspector : FactInspector
    {
        [Header("World State")]
        [FactId]
        [SerializeField]
        private string isHappy;

        public override void OnUpdate(WorldState worldState)
        {
            worldState.SetFact(this.isHappy, false);
        }
    }
}