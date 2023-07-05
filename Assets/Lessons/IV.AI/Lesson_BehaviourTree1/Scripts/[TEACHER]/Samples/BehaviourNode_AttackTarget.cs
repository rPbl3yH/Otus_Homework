// using AI.Blackboards;
// using Entities;
// using UnityEngine;
// using Blackboard = Lessons.AI.Architecture2.Blackboard;
//
// namespace Lessons.AI.BehaviourTree1
// {
//     public sealed class BehaviourNode_AttackTarget : BehaviourNode
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
//             var enemy = this.blackboard.GetVariable<UnityEntity>(this.enemyKey);
//             Debug.Log($"ATTACK ENEMY {enemy.name}");
//             this.Return(true);
//         }
//     }
// }