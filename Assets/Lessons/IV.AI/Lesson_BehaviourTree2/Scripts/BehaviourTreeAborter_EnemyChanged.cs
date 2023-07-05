using AI.Blackboards;
using Lessons.AI.Lesson_BehaviourTree1;
using UnityEngine;
using Blackboard = Lessons.AI.Architecture2.Blackboard;

namespace Lessons.AI.Lesson_BehaviourTree2
{
    public sealed class BehaviourTreeAborter_EnemyChanged : MonoBehaviour
    {
        [SerializeField]
        private BehaviourTree behaviourTree;

        [Space, SerializeField]
        private Blackboard blackboard;

        [SerializeField, BlackboardKey]
        private string enemyKey;

        private void OnEnable()
        {
            this.blackboard.OnVariableAdded += this.OnVariableChanged;
            this.blackboard.OnVariableRemoved += this.OnVariableChanged;
            this.blackboard.OnVariableChanged += this.OnVariableChanged;
        }
        
        private void OnDisable()
        {
            this.blackboard.OnVariableAdded -= this.OnVariableChanged;
            this.blackboard.OnVariableRemoved -= this.OnVariableChanged;
            this.blackboard.OnVariableChanged -= this.OnVariableChanged;
        }

        private void OnVariableChanged(string key, object _)
        {
            if (key == this.enemyKey)
            {
                this.behaviourTree.Abort();
            }
        }
    }
}