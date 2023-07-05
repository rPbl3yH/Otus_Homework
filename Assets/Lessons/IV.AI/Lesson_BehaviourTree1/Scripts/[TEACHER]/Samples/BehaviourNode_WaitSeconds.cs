// using System.Collections;
// using UnityEngine;
//
// namespace Lessons.AI.BehaviourTree1
// {
//     public sealed class BehaviourNode_WaitSeconds : BehaviourNode
//     {
//         [SerializeField]
//         private float seconds;
//
//         private Coroutine coroutine;
//         
//         protected override void Run()
//         {
//             this.coroutine = this.StartCoroutine(this.WaitForSeconds());
//         }
//
//         private IEnumerator WaitForSeconds()
//         {
//             Debug.Log($"NODE {name} WAIT {seconds}");
//             yield return new WaitForSeconds(this.seconds);
//             this.coroutine = null;
//             this.Return(true);
//         }
//
//         protected override void OnAbort()
//         {
//             if (this.coroutine != null)
//             {
//                 this.StopCoroutine(this.coroutine);
//                 this.coroutine = null;
//             }
//         }
//     }
// }