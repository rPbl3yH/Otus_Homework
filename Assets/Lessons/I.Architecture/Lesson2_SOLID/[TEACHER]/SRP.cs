// /// Нарушение SRP
// // public sealed class Player : MonoBehaviour
// // {
// //     [SerializeField] private float speed;
// //
// //     private void Update() {
// //         if (Input.GetKey(KeyCode.UpArrow)) {
// //             this.Move(Vector3.up);
// //         }
// //         else if (Input.GetKey(KeyCode.DownArrow)) {
// //             this.Move(Vector3.down);
// //         }
// //         
// //         if (Input.GetKey(KeyCode.LeftArrow)) {
// //             this.Move(Vector3.left);
// //         }
// //         else if (Input.GetKey(KeyCode.RightArrow)) {
// //             this.Move(Vector3.right);
// //         }
// //     }
// //
// //     private void Move(Vector3 direction) {
// //         this.transform.position += direction * Time.deltaTime * this.speed;
// //         this.transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
// //     }
// // }
//
// using System;
// using UnityEngine;
//
//     ///Правильное SRP
//     
//     public sealed class MoveComponent : MonoBehaviour {
//         
//         [SerializeField] private float speed;
//     
//         public void Move(Vector3 direction) {
//             this.transform.position += direction * this.speed;
//             this.transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
//         }
//     }
//     
//     
//     public sealed class MoveInput : MonoBehaviour
//     {
//         public event Action<Vector3> OnMove; 
//
//         private void Update() {
//             if (Input.GetKey(KeyCode.UpArrow)) 
//                 this.OnMove?.Invoke(Vector3.up * Time.deltaTime);
//             else if (Input.GetKey(KeyCode.DownArrow)) 
//                 this.OnMove?.Invoke(Vector3.down * Time.deltaTime);
//
//             if (Input.GetKey(KeyCode.LeftArrow))
//                 this.OnMove?.Invoke(Vector3.left * Time.deltaTime);
//             else if (Input.GetKey(KeyCode.RightArrow)) 
//                 this.OnMove?.Invoke(Vector3.right * Time.deltaTime);
//         }
//     }
//     
//     // public sealed class MoveController : MonoBehaviour
//     // {
//     //     [SerializeField] private MoveInput moveInput;
//     //     [SerializeField] private MoveComponent moveable;
//     //
//     //     private void OnEnable() => this.moveInput.OnMove += this.moveable.Move;
//     //     private void OnDisable() => this.moveInput.OnMove -= this.moveable.Move;
//     // }
//     //
//
//
