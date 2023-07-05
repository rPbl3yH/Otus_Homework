using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace AI.GOAP
{
    public abstract class PlanningActor : Actor, IActor.Callback
    {
        [SerializeField]
        private PlannerMode plannerMode;

        [SerializeField, Space]
        private Actor[] actions;

        private IPlanner planner;

        [Title("Debug")]
        [ShowInInspector, ReadOnly]
        private List<IActor> currentPlan;

        [ShowInInspector, ReadOnly]
        private int actionIndex;

        private void Awake()
        {
            this.planner = PlannerFactory.CreatePlanner(this.plannerMode, this.actions);
        }

        protected override void Play()
        {
            if (!this.CreatePlan(out this.currentPlan))
            {
                this.Return(false);
                return;
            }

            if (this.currentPlan.Count <= 0)
            {
                this.Return(true);
                return;
            }

            this.actionIndex = 0;
            this.currentPlan[this.actionIndex].Play(callback: this);
        }

        private bool CreatePlan(out List<IActor> plan)
        {
            this.worldState.UpdateFacts();
            return this.planner.MakePlan(this.worldState, this.requiredState, out plan);
        }

        void IActor.Callback.Invoke(IActor action, bool success)
        {
            if (!success)
            {
                this.Return(false);
                return;
            }

            var planCompleted = this.actionIndex + 1 >= this.currentPlan.Count;
            if (planCompleted)
            {
                this.Return(true);
            }

            this.actionIndex++;
            this.StartCoroutine(this.PerformNextAction());
        }

        private IEnumerator PerformNextAction()
        {
            yield return new WaitForFixedUpdate();
            this.currentPlan[this.actionIndex].Play(callback: this);
        }

        protected override void OnCancel()
        {
            if (this.currentPlan != null)
            {
                this.currentPlan[this.actionIndex].Cancel();
            }

            this.currentPlan = null;
            this.actionIndex = 0;
        }

        public override void Construct(WorldState worldState)
        {
            base.Construct(worldState);
            foreach (var action in this.actions)
            {
                action.Construct(this.worldState);
            }
        }
    }
}