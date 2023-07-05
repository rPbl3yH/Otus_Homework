using AI.Blackboards;
using Lessons.AI.Lesson_BehaviourTree1;
using UnityEngine;
using Blackboard = Lessons.AI.Architecture2.Blackboard;

namespace Lessons.AI.Lesson_BehaviourTree2
{
    public sealed class CheckBlackboardVariableNode : BehaviourNode
    {
        [SerializeField]
        private Blackboard blackboard;

        [SerializeField, BlackboardKey]
        private string variableName;
        
        protected override void Run()
        {
            var variableExists = this.blackboard.HasVariable(this.variableName);
            this.Return(variableExists);
        }
    }
}