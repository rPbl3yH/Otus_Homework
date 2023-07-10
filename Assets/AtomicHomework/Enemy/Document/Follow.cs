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
        public AtomicVariable<float> Speed;
        public AtomicVariable<float> MinDistance;
        
        public AtomicEvent<Transform> OnFollow = new();
        public AtomicEvent<Transform> OnTargetReach = new ();
        public AtomicEvent<Transform> OnTargetLose = new();

        public FixedUpdateMechanics FixedUpdateMechanics = new();

        private Transform _target;
        private bool _isMoveRequired;
        private bool _isCanMove;
        
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
                    if (_isCanMove)
                    {
                        enemyDocument.Transform.Translate(Vector3.forward * (Speed.Value * deltaTime));
                    }

                    var distance = Vector3.Distance(_target.position, enemyDocument.Transform.position);
                        
                    if (distance <= MinDistance.Value)
                    {
                        if (_isCanMove)
                        {
                            OnTargetReach?.Invoke(_target);
                        }
                        _isCanMove = false;
                    }
                    else
                    {
                        if (!_isCanMove)
                        {
                            OnTargetLose?.Invoke(_target);
                        }
                        _isCanMove = true;
                    }
                }
            });
        }
    }
}