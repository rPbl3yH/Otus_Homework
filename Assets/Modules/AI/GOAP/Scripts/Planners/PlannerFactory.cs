using System;
using System.Collections.Generic;

namespace AI.GOAP
{
    public static class PlannerFactory
    {
        public static IPlanner CreatePlanner(PlannerMode mode, IEnumerable<IActor> allActions)
        {
            if (mode == PlannerMode.Greedy)
            {
                return new GreedyPlanner(allActions);
            }

            if (mode == PlannerMode.AStar)
            {
                return new AStarPlanner(allActions);
            }

            if (mode == PlannerMode.Dijkstra)
            {
                return new DijkstraPlanner(allActions);
            }

            throw new Exception($"Undefined planner mode {mode}!");
        } 
    }
}