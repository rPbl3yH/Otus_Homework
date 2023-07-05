// using System;
// using UnityEngine;
//
// //Неправильное использование LSP 


    // public class Unit : MonoBehaviour {
    //     
    //     public int hitPoints;
    //     public int damage;
    //
    //     public virtual void Move(Vector3 vector) {
    //         this.transform.position += vector;
    //         this.transform.rotation = Quaternion.LookRotation(vector);
    //     }
    //
    //     public virtual void Attack(Unit target) {
    //         target.hitPoints -= damage;
    //     }
    // }
    //
    // public class Catapulta : Unit {
    //     
    //     public override void Move(Vector3 vector) {
    //         throw new Exception("Can't move!");
    //     }
    // }



//
// public class Worker : Unit {
//     
//     public override void Attack(Unit target)
//     {
//         throw new Exception("Can't attack!");
//     }
// }
//
// //Правильное использование:
// public class HitPointsComponent : MonoBehaviour {
//     public int hitPoints;
// }
//
// public class AttackComponent : MonoBehaviour {
//     
//     public int damage;
//
//     public void Attack(GameObject target) {
//         if (target.TryGetComponent(out HitPointsComponent component)) {
//             component.hitPoints -= this.damage;
//         }
//     }
// }
//
// public class MoveComponent : MonoBehaviour {
//     
//     public void Move(Vector3 vector) {
//         this.transform.position += vector;
//         this.transform.rotation = Quaternion.LookRotation(vector);
//     }
// }