// using UnityEngine;
//
// namespace Lessons.AI.BehaviourTree1
// {
//     public sealed class BehaviourNodeSelector : BehaviourNode, IBehaviourCallback
//     {
//         [SerializeField]
//         private BehaviourNode[] children;
//
//         private BehaviourNode currentChild;
//         
//         private int pointer;
//         
//         protected override void Run()
//         {
//             if (this.children.Length <= 0)
//             {
//                 this.Return(false);
//                 return;
//             }
//
//             this.pointer = 0;
//             this.currentChild = this.children[0];
//             this.currentChild.Run(callback: this);
//         }
//
//         void IBehaviourCallback.Invoke(BehaviourNode node, bool result)
//         {
//             if (result)
//             {
//                 this.Return(true);
//                 return;
//             }
//
//             if (this.pointer + 1 >= this.children.Length)
//             {
//                 this.Return(false);
//                 return;
//             }
//
//             this.pointer++;
//             this.currentChild = this.children[this.pointer];
//             this.currentChild.Run(callback: this);
//         }
//
//         protected override void OnAbort()
//         {
//             if (this.currentChild != null && this.currentChild.IsRunning)
//             {
//                 this.currentChild.Abort();
//             }
//         }
//
//         protected override void OnReturn(bool result)
//         {
//             Debug.Log($"NODE: {name} RETURN: {result}");
//         }
//
//         protected override void OnEnd()
//         {
//             this.currentChild = null;
//         }
//     }
// }