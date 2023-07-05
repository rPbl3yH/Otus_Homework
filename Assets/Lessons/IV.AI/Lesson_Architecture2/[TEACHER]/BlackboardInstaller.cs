// using AI.Blackboards;
// using AI.Iterators;
// using AI.Waypoints;
// using Entities;
// using UnityEngine;
//
// namespace Lessons.AI.Architecture2
// {
//     public sealed class BlackboardInstaller : MonoBehaviour
//     {
//         [SerializeField]
//         private Blackboard blackboard;
//
//         [Space]
//         [BlackboardKey]
//         [SerializeField]
//         private string unitKey;
//
//         // [BlackboardKey]
//         // [SerializeField]
//         // private string targetKey;
//
//         [BlackboardKey]
//         [SerializeField]
//         private string stoppingDistanceKey;
//
//         [BlackboardKey]
//         [SerializeField]
//         private string waypointsKey;
//
//         [BlackboardKey]
//         [SerializeField]
//         private string patrolPauseKey;
//
//         [Space]
//         [SerializeField]
//         private UnityEntity unit;
//
//         // [SerializeField]
//         // private UnityEntity target;
//
//         [SerializeField]
//         private float stoppingDistance;
//
//         [SerializeField]
//         private WaypointsPath waypoints;
//
//         [SerializeField]
//         private float patrolPause;
//
//         private void Awake()
//         {
//             this.blackboard.AddVariable(this.unitKey, this.unit);
//             // this.blackboard.AddVariable(this.targetKey, this.target);
//             this.blackboard.AddVariable(this.stoppingDistanceKey, this.stoppingDistance);
//             this.blackboard.AddVariable(this.waypointsKey, this.CreatePatrolIterator());
//             this.blackboard.AddVariable(this.patrolPauseKey, this.patrolPause);
//         }
//
//         private Iterator<Vector3> CreatePatrolIterator()
//         {
//             var points = this.waypoints.GetPositionPoints().ToArray();
//             return IteratorFactory.CreateIterator(IteratorMode.CIRCLE, points);
//         }
//     }
// }