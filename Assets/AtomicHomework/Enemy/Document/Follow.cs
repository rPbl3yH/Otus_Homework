using System;
using AtomicHomework.Atomic.Custom;
using Declarative;
using Lessons.Gameplay.Atomic1;
using UnityEngine;

namespace AtomicHomework.Enemy.Document
{
    [Serializable]
    public class Follow
    {
        public AtomicEvent<Transform> OnFollow = new();
        public AtomicVariable<float> Speed;
        public FixedUpdateMechanics FixedUpdateMechanics = new();

        private Transform _target;
        private bool _isMoveRequired;
        
        [Construct]
        public void Construct(EnemyDocument enemyDocument)
        {
            OnFollow += target =>
            {
                _target = target;
                _isMoveRequired = true;
            };
            
            FixedUpdateMechanics.OnUpdate(deltaTime =>
            {
                if (_isMoveRequired)
                {
                    enemyDocument.transform.LookAt(_target);
                    enemyDocument.Transform.Translate(Vector3.forward * (Speed.Value * deltaTime));
                }
            });
        }
    }
}