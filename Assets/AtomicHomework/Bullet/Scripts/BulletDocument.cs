using AtomicHomework.Atomic.Custom;
using Declarative;
using Lessons.Gameplay.Atomic1;
using UnityEngine;

namespace AtomicHomework.Bullet.Scripts
{
    public class BulletDocument : DeclarativeModel
    {
        public Transform Transform;
        public AtomicVariable<float> Speed;

        public FixedUpdateMechanics FixedUpdateMechanics = new();
        
        [Construct]
        public void Construct()
        {
            FixedUpdateMechanics.OnUpdate(deltaTime =>
            {
                Transform.Translate(Vector3.forward * (Speed.Value * deltaTime));
            });
        }
    }
}