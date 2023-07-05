// using AI.Waypoints;
// using Elementary;
// using Entities;
// using Game.GameEngine;
// using UnityEngine;
// using static AI.Agents.Agent_MoveToPosition;
//
// namespace Lessons.TEACHERPREV
// {
//     public sealed class AIState_Patrol : State
//     {
//         [SerializeField]
//         public UnityEntity unit;
//
//         [SerializeField]
//         public WaypointsPath pointsPath;
//
//         [SerializeField]
//         public float stoppingDistance = 0.15f;
//         
//         private Agent_MoveEntiyToPosition moveAgent;
//
//         private Iterator<Vector3> pointsIterator;
//         
//         public override void Enter()
//         {
//             this.moveAgent.OnFinished += this.OnMoveFinished;
//             this.StartMove();
//         }
//
//         public override void Exit()
//         {
//             this.moveAgent.Cancel();
//             this.moveAgent.OnFinished -= this.OnMoveFinished;
//         }
//         
//         private void OnMoveFinished()
//         {
//             this.pointsIterator.MoveNext();
//             this.StartMove();
//         }
//         
//         private void StartMove()
//         {
//             var nextPoint = this.pointsIterator.Current;
//             var args = new Data(nextPoint, this.stoppingDistance);
//             this.moveAgent.Start(args);
//         }
//         
//         private void Awake()
//         {
//             this.moveAgent = new Agent_MoveEntiyToPosition(this, this.unit);
//             var patrolPositions = this.pointsPath.GetPositionPoints();
//             this.pointsIterator = new CircleIterator<Vector3>(patrolPositions.ToArray());
//         }
//     }
// }