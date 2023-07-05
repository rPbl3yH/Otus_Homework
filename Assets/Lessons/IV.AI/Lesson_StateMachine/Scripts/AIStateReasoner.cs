// using UnityEngine;
//
// namespace Lessons.TEACHERPREV
// {
//     public sealed class AIStateReasoner : MonoBehaviour
//     {
//         [SerializeField]
//         private AIStateMachine stateMachine;
//
//         [SerializeField]
//         private HeroSensor sensor;
//
//         private void OnEnable()
//         {
//             this.sensor.OnHeroReached += this.OnHeroEntered;
//             this.sensor.OnHeroUnreached += this.OnHeroExited;
//         }
//
//         private void OnDisable()
//         {
//             this.sensor.OnHeroReached -= this.OnHeroEntered;
//             this.sensor.OnHeroUnreached -= this.OnHeroExited;
//         }
//
//         private void OnHeroEntered()
//         {
//             this.stateMachine.SwitchState(AIMode.ATTACK);
//         }
//
//         private void OnHeroExited()
//         {
//             this.stateMachine.SwitchState(AIMode.PATROL);
//         }
//     }
// }