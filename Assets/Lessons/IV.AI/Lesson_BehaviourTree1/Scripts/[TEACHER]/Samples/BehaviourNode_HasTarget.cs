// using AI.Blackboards;
// using UnityEngine;
//
// namespace Lessons.AI.BehaviourTree1
// {
//     public sealed class BehaviourNode_HasTarget : BehaviourNode
//     {
//         [SerializeField]
//         private Blackboard blackboard;
//
//         [BlackboardKey]
//         [SerializeField]
//         private string enemyKey;
//         
//         protected override void Run()
//         {
//             var isSuccess = this.blackboard.HasVariable(this.enemyKey);
//             this.Return(isSuccess);
//         }
//     }
// }