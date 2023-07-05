// using Elementary;
// using Entities;
// using Game.GameEngine;
// using UnityEngine;
// using static AI.Agents.Agent_FollowToTargetPosition;
//
// namespace Lessons.TEACHERPREV
// {
//     public sealed class AIState_Attack : State, IProvider
//     {
//         [SerializeField]
//         private HeroSensor heroSensor;
//
//         [SerializeField]
//         public UnityEntity unit;
//
//         [SerializeField]
//         public float stoppingDistance = 0.25f;
//
//         [Space]
//         [SerializeField]
//         public CombatService attackManager;
//
//         private IEntity targetHero;
//
//         private ITransformComponent targetHeroTransform;
//
//         private Agent_FollowToEntity followAgent;
//
//
//         public override void Enter()
//         {
//             this.targetHero = this.heroSensor.Hero;
//             this.targetHeroTransform = this.targetHero.Get<ITransformComponent>();
//
//             this.followAgent.OnTargetReached += this.OnTargetReached;
//             this.followAgent.OnTargetUnreached += this.OnTargetUnreached;
//             this.followAgent.Start(provider: this);
//         }
//
//         public override void Exit()
//         {
//             this.followAgent.Cancel();
//             this.followAgent.OnTargetReached -= this.OnTargetReached;
//             this.followAgent.OnTargetUnreached -= this.OnTargetUnreached;
//         }
//
//         private void OnTargetReached()
//         {
//             this.attackManager.StartCombat(this.targetHero);
//         }
//
//         private void OnTargetUnreached()
//         {
//             this.attackManager.CancelCombat();
//         }
//
//         private void Awake()
//         {
//             this.followAgent = new Agent_FollowToEntity(this, this.unit);
//         }
//
//         Vector3 IProvider.GetTargetPosition()
//         {
//             return this.targetHeroTransform.Position;
//         }
//
//         float IProvider.GetStoppingDistance()
//         {
//             return this.stoppingDistance;
//         }
//     }
// }