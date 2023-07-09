using System;
using Declarative;
using Lessons.Gameplay.Atomic1;
using UnityEngine;
using UnityEngine.Serialization;

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
        
        [Construct]
        public void Construct()
        {
            OnFire += () =>
            {
                if (IsCanAttack.Value)
                {
                    GameObject.Instantiate(BulletPrefab, SpawnPoint.position, SpawnPoint.rotation);
                    BulletCount.Value--;
                }
            };

            BulletCount.OnChanged += count =>
            {
                IsCanAttack.Value = count > 0;
                
            };
        }
    }
}