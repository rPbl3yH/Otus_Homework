using UnityEngine;

namespace AI.GOAP
{
    [AddComponentMenu("AI/GOAP/Goal Oriented Looper")]
    [RequireComponent(typeof(GoalOrientedAgent))]
    [DisallowMultipleComponent]
    public sealed class GoalOrientedLooper : MonoBehaviour
    {
        [SerializeField]
        private UpdateMode updateMode;

        private GoalOrientedAgent agent;

        private void Awake()
        {
            this.agent = this.GetComponent<GoalOrientedAgent>();
        }

        private void Update()
        {
            if (this.updateMode == UpdateMode.UPDATE)
            {
                this.agent.TryPlay();
            }
        }

        private void FixedUpdate()
        {
            if (this.updateMode == UpdateMode.FIXED_UPDATE)
            {
                this.agent.TryPlay();
            }
        }

        private void LateUpdate()
        {
            if (this.updateMode == UpdateMode.LATE_UPDATE)
            {
                this.agent.TryPlay();
            }
        }

        private enum UpdateMode
        {
            NONE = 0,
            UPDATE = 1,
            FIXED_UPDATE = 2,
            LATE_UPDATE = 3
        }
    }
}