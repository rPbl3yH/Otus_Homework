using System;
using AtomicHomework.Atomic.Custom;
using AtomicHomework.Entities.Components;
using Declarative;
using Entities;
using Lessons.Gameplay.Atomic1;
using UnityEngine;

namespace AtomicHomework.Enemy.Document
{
    [Serializable]
    public class Attack
    {
        public AtomicVariable<int> Damage;
        public AtomicVariable<float> TimeToAttack;
        public TimerMechanics TimerMechanics;

        public AtomicVariable<bool> IsCanAttack;
        public AtomicEvent<Transform> OnAttack = new();
        private Transform _target;
            
        [Construct]
        public void Construct(Follow follow)
        {
            TimerMechanics.Construct(TimeToAttack.Value);

            TimerMechanics.OnTimerFinished += () =>
            {
                IsCanAttack.Value = true;
                TimerMechanics.StopTimer();
                
                if (_target != null)
                {
                    OnAttack?.Invoke(_target);
                }
            };
            
            follow.OnTargetReach += target =>
            {
                _target = target;
                OnAttack?.Invoke(target);
            };

            follow.OnTargetLose += _ =>
            {
                _target = null;
            };

            OnAttack += target =>
            {
                if (IsCanAttack.Value)
                {
                    if (target.TryGetComponent(out IEntity entity))
                    {
                        if (entity.TryGet(out ITakeDamageComponent takeDamageComponent))
                        {
                            takeDamageComponent.TakeDamage(Damage.Value);
                            IsCanAttack.Value = false;
                            TimerMechanics.StartTimer();
                        }
                    }
                }
            };
        }
    }
}