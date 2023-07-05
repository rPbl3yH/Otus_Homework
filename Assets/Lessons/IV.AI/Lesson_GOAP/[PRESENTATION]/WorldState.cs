// using System;
// using System.Collections.Generic;
//
// // ReSharper disable UnusedMember.Global
// // ReSharper disable EventNeverSubscribedTo.Global
// // ReSharper disable UnusedType.Global
//
// namespace Presentation.AI.Lesson_GOAP
// {
//     public struct Parameter
//     {
//         public string name;
//         public bool value;
//     }
//
//     public interface IWorldState
//     {
//         event Action<Parameter> OnParameterChanged;
//         event Action<Parameter> OnParameterAdded;
//         event Action<Parameter> OnParameterRemoved; 
//
//         bool GetParameter(string name);
//         bool TryGetParameter(string name, out bool value);
//         void ChangeParameter(string name, bool value);
//         void AddParameter(string name, bool value);
//         void RemoveParameter(string name);
//         bool ContainsParameter(string name);
//     }
//     
//     public interface IGoal
//     {
//         string Name { get; }
//         Parameter[] DesiredState { get; }
//         
//         int EvaluatePriority();
//         bool IsValid();
//     }
//     
//     public interface IAction
//     {
//         string Name { get; }
//         Parameter[] RequiredState { get; }
//         Parameter[] SatisfiedState { get; }
//
//         int EvaluateCost();
//         bool IsValid();
//     }
//     
//     public interface IGoalPlanner
//     {
//         bool MakePlan(out Plan plan);
//
//         void RegisterGoal(IGoal goal);
//         void UnregisterGoal(IGoal goal);
//         void RegisterAction(IAction action);
//         void UnregisterAction(IAction action);
//     }
//     
//     public struct Plan
//     {
//         public IGoal goal;
//         public  IAction[] actions;
//
//         public Plan(IGoal goal, IAction[] actions)
//         {
//             this.goal = goal;
//             this.actions = actions;
//         }
//     }
//     
//     public static class PlanAlgorithm
//     {
//         public static bool BuildPlan(IGoal goal, IAction[] actions, IWorldState worldState, out Plan plan) {
//             var targetParameters = goal.DesiredState;
//             if (worldState.MatchesWithParameters(targetParameters)) {
//                 plan = new Plan(goal, new IAction[0]);
//                 return true;
//             }
//
//             var actionList = new List<IAction>();
//             while (FindCheapestAction(targetParameters, actions, out var nextAction)) {
//                 actionList.Add(nextAction);
//                 targetParameters = nextAction.RequiredState;
//
//                 if (worldState.MatchesWithParameters(targetParameters)) {
//                     actionList.Reverse();                
//                     plan = new Plan(goal, actionList.ToArray());
//                     return true;
//                 }
//             }
//
//             plan = default;
//             return false;
//         }
//         
//         //TODO: FindCheapestActionAStar(Parameter[] requiredParameters, IAction[] actions, out IAction result)
//         
//         public static bool FindCheapestAction(Parameter[] requiredParameters, IAction[] actions, out IAction result)
//         {
//             result = null;
//             var currentCost = int.MaxValue;
//
//             for (int i = 0, count = actions.Length; i < count; i++)
//             {
//                 var action = actions[i];
//                 if (!action.SatisfiedState.Includes(requiredParameters))
//                 {
//                     continue;
//                 }
//
//                 var cost = action.EvaluateCost();
//                 if (result == null || currentCost > cost)
//                 {
//                     result = action;
//                     currentCost = cost;
//                 }
//             }
//
//             return result != null;
//         }
//     }
//     
// }
//
//
