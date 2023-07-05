using System.Collections.Generic;
using System.Linq;

namespace AI.GOAP
{
    public sealed class GreedyPlanner : IPlanner
    {
        private readonly IEnumerable<IActor> allActions;

        public GreedyPlanner(IEnumerable<IActor> allActions)
        {
            this.allActions = allActions;
        }

        public bool MakePlan(IFactState worldState, IFactState goal, out List<IActor> plan)
        {
            plan = new List<IActor>(0);
            if (goal.EqualsTo(worldState))
            {
                return true;
            }

            var actions = this.allActions.Where(it => it.IsValid());

            while (this.FindCheapestAction(goal, actions, out var nextAction))
            {
                plan.Add(nextAction);
                goal = nextAction.RequiredState;
                if (goal.EqualsTo(worldState))
                {
                    plan.Reverse();
                    return true;
                }
            }

            plan = default;
            return false;
        }

        private bool FindCheapestAction(IFactState requiredState, IEnumerable<IActor> actions, out IActor result)
        {
            result = null;
            var currentCost = int.MaxValue;

            foreach (var action in actions)
            {
                if (!requiredState.EqualsTo(action.ResultState))
                {
                    continue;
                }

                var cost = action.EvaluateCost();
                if (result == null || currentCost > cost)
                {
                    result = action;
                    currentCost = cost;
                }
            }

            return result != null;
        }
    }
}