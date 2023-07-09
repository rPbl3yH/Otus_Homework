using System;
using AtomicHomework.Atomic.Custom;
using Declarative;
using Lessons.Gameplay.Atomic1;
using UnityEngine;

namespace AtomicHomework.Hero
{
    [Serializable]
    public class Fire
    {
        public GameObject BulletPrefab;
        public Transform SpawnPoint;
        public AtomicVariable<int> Delay;

        public AtomicVariable<int> BulletCount;
        public AtomicEvent OnFire = new();

        public AtomicVariable<bool> IsCanAttack;
        public TimerMechanics TimerMechanics;
        
        
        [Construct]
        public void Construct()
        {
            TimerMechanics.Construct(Delay.Value);

            OnFire += () =>
            {
                if (IsCanAttack.Value)
                {
                    GameObject.Instantiate(BulletPrefab, SpawnPoint.position, SpawnPoint.rotation);
                    BulletCount.Value--;
                    TimerMechanics.StartTimer();
                }
            };

            TimerMechanics.OnTimerFinished += () =>
            {
                BulletCount.Value++;
                
                if (BulletCount.Value == 5)
                {
                    TimerMechanics.StopTimer();
                }
            };

            BulletCount.OnChanged += count =>
            {
                IsCanAttack.Value = count > 0;
            };
        }
    }
}