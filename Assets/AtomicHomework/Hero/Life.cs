using System;
using Declarative;
using Lessons.Gameplay.Atomic1;
using Sirenix.OdinInspector;
using UnityEngine;

namespace AtomicHomework.Hero
{
    [Serializable]
    public class Life
    { 
        [SerializeField]
        public AtomicVariable<int> HitPoints ;
        [ShowInInspector]
        public AtomicEvent<int> OnTakeDamage = new();
        [ShowInInspector]
        public AtomicEvent OnDeath = new();
        
        [Construct]
        public void Construct()
        {
            OnTakeDamage += damage =>
            {
                HitPoints.Value -= damage;
            };

            HitPoints.OnChanged += hitPoints =>
            {
                if (hitPoints <= 0)
                {
                    OnDeath?.Invoke();
                }
            };

            OnDeath += () => Debug.Log("Death");
        }
    }
}