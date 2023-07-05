using System.Collections;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace AI.GOAP
{
    [AddComponentMenu("AI/GOAP/Goal Oriented Inspector")]
    [RequireComponent(typeof(GoalOrientedAgent))]
    [DisallowMultipleComponent]
    public sealed class GoalOrientedInspector : MonoBehaviour
    {
        [Space]
        [SerializeField]
        private bool playOnStart = true;
        
        [Space]
        [SerializeField]
        private float minScanPeriod = 0.1f;

        [SerializeField]
        private float maxScanPeriod = 0.2f;

        private GoalOrientedAgent agent;
        
        private Coroutine coroutine;
        
        private void Awake()
        {
            this.agent = this.GetComponent<GoalOrientedAgent>();
        }

        private void Start()
        {
            if (this.playOnStart)
            {
                this.Play();
            }
        }

        public void Play()
        {
            if (this.coroutine == null)
            {
                this.coroutine = this.StartCoroutine(this.InspectGoalsLoop());
            }
        }

        public void Stop()
        {
            if (this.coroutine != null)
            {
                this.StopCoroutine(this.coroutine);
                this.coroutine = null;
            }
        }

        private IEnumerator InspectGoalsLoop()
        {
            while (true)
            {
                var period = Random.Range(this.minScanPeriod, this.maxScanPeriod);
                yield return new WaitForSeconds(period);
                this.InspectGoals();
            }
        }

        private void InspectGoals()
        {
            var actualGoal = this.agent.AllGoals
                .Where(it => it.IsValid())
                .OrderByDescending(it => it.EvaluatePriority())
                .First();

            if (!actualGoal.Equals(this.agent.CurrentGoal))
            {
                this.agent.Replay();
            }
        }
    }
}