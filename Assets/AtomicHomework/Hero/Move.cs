using System;
using AtomicHomework.Atomic.Custom;
using Declarative;
using Lessons.Gameplay.Atomic1;
using UnityEngine;

namespace AtomicHomework.Hero
{
    [Serializable]
    public class Move
    {
        [SerializeField] public AtomicVariable<float> Speed;
        public AtomicEvent<Vector3> OnMove = new();
        
        private Transform _transform;
        private Vector3 _direction;
        private bool _isMoveRequired;

        public FixedUpdateMechanics FixedUpdateMechanics = new();

        [Construct]
        public void Construct(HeroDocument heroDocument)
        {
            _transform = heroDocument.Transform;
            
            OnMove += direction =>
            {
                _direction = direction;
                _isMoveRequired = true;
            };
            
            FixedUpdateMechanics.OnUpdate(deltaTime =>
            {
                if (_isMoveRequired)
                {
                    _transform.Translate(_direction * (Speed.Value * deltaTime));
                    _isMoveRequired = false;
                }   
            });
        }
    }
}