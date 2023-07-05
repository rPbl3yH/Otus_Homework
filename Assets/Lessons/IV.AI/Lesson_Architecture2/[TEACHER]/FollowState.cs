// using AI.Blackboards;
// using Elementary;
// using Entities;
// using Game.GameEngine.Mechanics;
// using UnityEngine;
// using UnityEngine.Serialization;
//
// namespace Lessons.AI.Architecture2
// {
//     public sealed class FollowState : MonoState
//     {
//         [SerializeField]
//         private Blackboard blackboard;
//
//         [SerializeField]
//         private MoveAgent agent;
//
//         [BlackboardKey]
//         [SerializeField]
//         private string unitKey;
//
//         [BlackboardKey]
//         [SerializeField]
//         private string targetKey;
//
//         [FormerlySerializedAs("stoppingDistance")]
//         [BlackboardKey]
//         [SerializeField]
//         private string stoppingDistanceKey;
//
//         private IComponent_GetPosition targetComponent;
//
//         private void Awake()
//         {
//             this.enabled = false;
//         }
//
//         private void FixedUpdate()
//         {
//             this.UpdateTargetPosition();
//         }
//
//         public override void Enter()
//         {
//             if (!this.blackboard.TryGetVariable(this.unitKey, out IEntity unit))
//             {
//                 return;
//             }
//
//             if (!this.blackboard.TryGetVariable(this.targetKey, out IEntity target))
//             {
//                 return;
//             }
//
//             if (!this.blackboard.TryGetVariable(this.stoppingDistanceKey, out float stoppingDistance))
//             {
//                 return;
//             }
//
//             this.targetComponent = target.Get<IComponent_GetPosition>();
//             
//             this.agent.SetUnit(unit);
//             this.agent.SetStoppingDistance(stoppingDistance);
//             this.agent.Play();
//             this.enabled = true;
//         }
//
//         public override void Exit()
//         {
//             this.agent.Stop();
//             this.enabled = false;
//         }
//
//         private void UpdateTargetPosition()
//         {
//             var targetPosition = this.targetComponent.Position;
//             this.agent.SetTargetPosiiton(targetPosition);
//         }
//     }
// }