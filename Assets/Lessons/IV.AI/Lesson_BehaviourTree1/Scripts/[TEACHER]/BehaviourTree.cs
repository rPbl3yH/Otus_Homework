// using System;
// using UnityEngine;
//
// namespace Lessons.AI.BehaviourTree1
// {
//     public sealed class BehaviourTree : BehaviourNode, IBehaviourCallback
//     {
//         public event Action OnStarted; 
//
//         public event Action<bool> OnFinished;
//
//         public event Action OnAborted;
//
//         [SerializeField]
//         private BehaviourNode rootNode;
//
//         [Space]
//         [SerializeField]
//         private bool autoRun;
//
//         [SerializeField]
//         private bool loop;
//         
//         private void Start()
//         {
//             if (this.autoRun)
//             {
//                 this.Run();
//             }
//         }
//
//         private void FixedUpdate()
//         {
//             if (this.loop)
//             {
//                 this.Run();
//             }
//         }
//
//         protected override void Run()
//         {
//             if (!this.rootNode.IsRunning)
//             {
//                 this.OnStarted?.Invoke();
//                 this.rootNode.Run(callback: this);
//             }
//         }
//
//         protected override void OnAbort()
//         {
//             if (this.rootNode.IsRunning)
//             {
//                 this.rootNode.Abort(); //Cancel
//                 this.OnAborted?.Invoke();
//             }
//         }
//
//         void IBehaviourCallback.Invoke(BehaviourNode node, bool result) //success/fail
//         {
//             this.Return(result);
//             this.OnFinished?.Invoke(result);
//         }
//     }
// }