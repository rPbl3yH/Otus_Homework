using System.Collections.Generic;
using AI.Blackboards;
using AI.Iterators;
using AI.Waypoints;
using Entities;
using UnityEngine;

namespace Lessons.AI.Architecture2
{
    public sealed class BlackboardInstaller : MonoBehaviour
    {
        [SerializeField]
        private Blackboard blackboard;

        [Space]
        [BlackboardKey]
        [SerializeField]
        private string unitKey;

        [SerializeField]
        private MonoEntity unitEntity;

        [Space]
        [BlackboardKey]
        [SerializeField]
        private string stoppingDistanceKey;

        [SerializeField]
        private float stoppingDistance;

        [Space]
        [BlackboardKey]
        [SerializeField]
        private string waypointsKey;

        [SerializeField]
        private WaypointsPath waypoints;
        
        [Space]
        [SerializeField]
        [BlackboardKey]
        private string patrolDelayKey;
        
        [SerializeField]
        private float patrolDelay = 1.0f;
        
        private void Awake()
        {
            this.blackboard.AddVariable(this.unitKey, this.unitEntity);
            this.blackboard.AddVariable(this.stoppingDistanceKey, this.stoppingDistance);
            this.blackboard.AddVariable(this.waypointsKey, this.CreateWaypointsIterator());
            this.blackboard.AddVariable(this.patrolDelayKey, this.patrolDelay);
        }

        private IEnumerator<Vector3> CreateWaypointsIterator()
        {
            IEnumerator<Vector3> iterator;
            Vector3[] waypoints = this.waypoints.GetPositionPoints().ToArray();
            iterator = IteratorFactory.CreateIterator(IteratorMode.CIRCLE, waypoints);
            return iterator;
        }
    }
}