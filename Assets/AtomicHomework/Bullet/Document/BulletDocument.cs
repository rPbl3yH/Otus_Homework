using AtomicHomework.Atomic.Custom;
using AtomicHomework.Bullet.Mechanics;
using AtomicHomework.Entities.Components;
using Declarative;
using Lessons.Gameplay.Atomic1;
using UnityEngine;

namespace AtomicHomework.Bullet.Document
{
    public class BulletDocument : DeclarativeModel
    {
        public Transform Transform;
        public AtomicVariable<float> Speed;

        public FixedUpdateMechanics FixedUpdateMechanics = new();
        public CollideDetectionMechanic CollideDetectionMechanic = new();

        public AtomicVariable<int> Damage;

        [Construct]
        public void Construct()
        {
            FixedUpdateMechanics.OnUpdate(deltaTime =>
            {
                Transform.Translate(Vector3.forward * (Speed.Value * deltaTime));
            });

            CollideDetectionMechanic.OnTriggerEntered += entity =>
            {
                if (entity.TryGet(out ITakeDamageComponent takeDamageComponent))
                {
                    takeDamageComponent.TakeDamage(Damage.Value);
                }
            };
        }
    }
}