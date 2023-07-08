using System;
using AtomicHomework.Atomic.Custom;
using Declarative;
using Lessons.Gameplay.Atomic1;
using UnityEngine;
using UnityEngine.Serialization;

namespace AtomicHomework.Hero
{
    [Serializable]
    public class Rotate
    {
        [SerializeField] public AtomicVariable<float> RotationSpeed;
        [SerializeField] public AtomicVariable<Vector3> Direction;
        
        public RotateEngine Engine = new();
        public UpdateMechanics UpdateMechanics = new();

        [Construct]
        public void Construct(HeroDocument heroDocument)
        {
            Engine.Construct(heroDocument.Transform, RotationSpeed, Direction);

            UpdateMechanics.OnUpdate(_ => Engine.Rotate());
        }
    }
}