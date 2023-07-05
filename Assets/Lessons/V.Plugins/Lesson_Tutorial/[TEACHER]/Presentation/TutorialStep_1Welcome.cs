// // ReSharper disable UnusedType.Global
//
// using System;
// using System.Collections.Generic;
// // ReSharper disable UnusedMember.Global
// // ReSharper disable UnassignedGetOnlyAutoProperty
// // ReSharper disable EventNeverSubscribedTo.Global
// #pragma warning disable CS0067
//
// #pragma warning disable CS0169
//
// namespace Lessons.PRESENTATION.TUTORIAL
// {
//     
//     
//     
     // public class TutorialManager {
     //     
     //     public event Action OnCompleted;
     //     public event Action<ITutorialStep> OnStepChanged;
     //
     //     public bool isCompleted;
     //     private List<ITutorialStep> steps;
     //     private int currentIndex;
     //
     //     //TODO: Some logic
     // }
     //
     // public interface ITutorialStep {
     //     
     //     public abstract event Action OnCompleted;
     //     public abstract void Start();
     // }
     //
     //


//
//     
//     
//     
//     public class TutorialManager {
//         
//         public event Action<TutorialStep> OnStepFinished;
//         public event Action<TutorialStep> OnStepChanged; 
//         public event Action OnCompleted;
//
//         public bool isCompleted;
//         public TutorialStep currentStep;
//         private List<TutorialStep> stepList;
//         private int currentIndex;
//
//         public void FinishCurrentStep(){}
//         public void MoveToNextStep(){}
//     }
//
//     public enum TutorialStep {
//         WELCOME,
//         KILL_DRAGON,
//         SAVE_PRINCESS
//     }
//     
//     
//     
//     public sealed class TutorialStep_1Welcome : TutorialStep
//     {
//         //TODO: Show welcome popup
//     }
//
//     public sealed class TutorialStep_2KillDragon : TutorialStep
//     {
//         //TODO: Kill enemies quest
//     }
//
//     public sealed class TutorialStep_3SavePrincess : TutorialStep
//     {
//         //TODO: Come to a princess
//     }
// }