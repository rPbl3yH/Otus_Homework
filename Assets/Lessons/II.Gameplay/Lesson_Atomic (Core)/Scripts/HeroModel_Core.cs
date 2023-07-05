using System;
using Declarative;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Gameplay.Atomic1
{
    [Serializable]
    public sealed class HeroModel_Core
    {
        [Section]
        [SerializeField]
        public Life life = new();

        [Section]
        [SerializeField]
        public Move move = new();

        [Serializable]
        public sealed class Life
        {
            [ShowInInspector]
            public AtomicEvent<int> onTakeDamage = new();

            [SerializeField]
            public AtomicVariable<int> hitPoints = new();

            [SerializeField]
            public AtomicVariable<bool> isDeath;

            [Construct]
            public void Construct()
            {
                this.onTakeDamage += damage => this.hitPoints.Value -= damage;
                this.hitPoints.OnChanged += hitPoints =>
                {
                    if (hitPoints <= 0) this.isDeath.Value = true;
                };
            }
        }

        [Serializable]
        public sealed class Move
        {
            [SerializeField]
            public Transform moveTransform;

            [ShowInInspector]
            public AtomicEvent<Vector3> onMove = new();

            [SerializeField]
            public AtomicVariable<bool> moveRequired = new();

            [SerializeField]
            public AtomicVariable<Vector3> moveDirection = new();

            [SerializeField]
            public AtomicVariable<float> speed = new();

            private readonly FixedUpdateMechanics fixedUpdate = new();

            [Construct]
            public void Construct(Life life)
            {
                var isDeath = life.isDeath;
                this.onMove += direction =>
                {
                    if (isDeath.Value)
                    {
                        return;
                    }

                    this.moveDirection.Value = direction;
                    this.moveRequired.Value = true;
                };

                this.fixedUpdate.Do(deltaTime =>
                {
                    if (this.moveRequired.Value)
                    {
                        this.moveTransform.position += this.moveDirection.Value * (this.speed.Value * deltaTime);
                        this.moveRequired.Value = false;
                    }
                });
            }
        }
    }
}