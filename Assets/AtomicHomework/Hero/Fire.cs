using System;
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

        public AtomicEvent OnFire = new();

        [Construct]
        public void Construct()
        {
            OnFire += () =>
            {
                GameObject.Instantiate(BulletPrefab, SpawnPoint.position, SpawnPoint.rotation);
            };
        }
    }
}