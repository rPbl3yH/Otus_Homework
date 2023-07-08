using System;
using Declarative;
using Lessons.Gameplay.Atomic1;
using UnityEngine;

namespace AtomicHomework.Hero
{
    [Serializable]
    public class Move
    {
        [SerializeField] public AtomicVariable<float> Speed;
        
        public MoveEngine Engine = new();

        [Construct]
        public void Construct(HeroDocument heroDocument)
        {
            Engine.Construct(heroDocument.Transform, Speed);
        }
    }
}